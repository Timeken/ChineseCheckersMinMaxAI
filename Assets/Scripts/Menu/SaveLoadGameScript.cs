using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveLoadGameScript : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    public List<string> gameObjectNames;
    private string path;
    private PlayerScript playerScript;
    private GameSettingsScript settingsScript;
    private SetupScript setupScript;
    private void Start()
    {
        settingsScript = camera.GetComponent<GameSettingsScript>();
        playerScript = camera.GetComponent<PlayerScript>();
        setupScript = camera.GetComponent<SetupScript>();
        path = Application.persistentDataPath + "/save.dat";
    }
//----------------------------------------------------------------Save------------------------------------------------------------------
    public void SaveFile()
    {
        gameObjectNames = new List<string>();       
        //Add gamemode
        if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers)
        {
            gameObjectNames.Add("two");
        }
        else if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.threePlayers)
        {
            gameObjectNames.Add("three");
        }
        else if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.forePlayers)
        {
            gameObjectNames.Add("fore");
        }
        else if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.sixPlayers)
        {
            gameObjectNames.Add("six");
        }
        for (int i = 0; i < playerScript.GamePieces.Length; i++)
        {
            gameObjectNames.Add(playerScript.GamePieces[i].name + "," + playerScript.GamePieces[i].GetComponent<GamePieceScript>().Occuping.name);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, gameObjectNames);
        stream.Close();
    }
//--------------------------------------------------------------Load------------------------------------------------------------------
    public void LoadFile()
    {
        GameObject[] teamGamePieces = setupScript.TeamGamePieces;
        GameObject[] twoPlayerGamePieces = setupScript.TwoPlayerGamePieces;
        //make all gamepieces active otherwise it wont work if you load the game
        for (int i = 0; i < teamGamePieces.Length; i++) 
        {
            teamGamePieces[i].SetActive(true);
        }
        //deactivate two player mode 
        for (int i = 0; i < twoPlayerGamePieces.Length; i++)
        {
            twoPlayerGamePieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().tag = "Untagged";
            twoPlayerGamePieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
            twoPlayerGamePieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<Renderer>().material.color = Color.gray;
            twoPlayerGamePieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Color = 0;           
        }
        setupScript.TwoPlayers.SetActive(false);

        gameObjectNames = new List<string>();
        string gameMode;

        BinaryFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Open);
        gameObjectNames = (List<string>)formatter.Deserialize(stream);
        stream.Close();
        for(int i = 0; i < gameObjectNames.Count; i++)
        {
            if (i == 0)
            {
                gameMode = gameObjectNames[i];
                //Check gamemode and call setup
                switch (gameMode)
                {
                    case "two":
                        settingsScript.NumbersOfPlayers = NumbersOfPlayers.twoPlayers;
                        break;
                    case "three":
                        settingsScript.NumbersOfPlayers = NumbersOfPlayers.threePlayers;
                        break;
                    case "fore":
                        settingsScript.NumbersOfPlayers = NumbersOfPlayers.forePlayers;
                        break;
                    case "six":
                        settingsScript.NumbersOfPlayers = NumbersOfPlayers.sixPlayers;
                        break;
                }
                setupScript.Setup(settingsScript.NumbersOfPlayers);//Run setup
            }
            else
            {
                string temp = gameObjectNames[i];

                string[] tempArray = temp.Split(
                new string[] { "," }, StringSplitOptions.None);
                //find gameobject and move it
                GameObject tempGamePiece = GameObject.Find(tempArray[0]);
                GameObject tempBoard = GameObject.Find(tempArray[1]);
                tempGamePiece.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                tempGamePiece.GetComponent<GamePieceScript>().Occuping = tempBoard;
                tempBoard.GetComponent<BoardScript>().Occupied = true;

                float hight = 0.05f;
                tempGamePiece.transform.position = tempBoard.transform.position + new Vector3(0, hight, 0);
            }
        }
    }
}
