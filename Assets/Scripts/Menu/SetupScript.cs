using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScript : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject[] gamePieces;
    [SerializeField]
    private GameObject[] teamGamePieces;
    [SerializeField]
    private GameObject[] twoPlayerGamePieces;
    [SerializeField]
    private GameObject twoPlayers;

    public GameObject TwoPlayers
    {
        get { return twoPlayers; }
        set { twoPlayers = value; }
    }
    public GameObject[] GamePieces
    {
        get { return gamePieces; }
        set { gamePieces = value; }
    }
    public GameObject[] TeamGamePieces
    {
        get { return teamGamePieces; }
        set { teamGamePieces = value; }
    }
    public GameObject[] TwoPlayerGamePieces
    {
        get { return twoPlayerGamePieces; }
        set { twoPlayerGamePieces = value; }
    }

    private PlayerScript playerScript; 

    void Start()
    {
        playerScript = camera.GetComponent<PlayerScript>();
    }
    public void Setup(NumbersOfPlayers numbersOfPlayers)
    {
        //----------------------------------------------------------------------GameSetupTwoPlayers--------------------------------------------------------------------
        if (numbersOfPlayers == NumbersOfPlayers.twoPlayers)
        {           
            //Remove yellow from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("YellowGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Remove Balck from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("BlackGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Remove red from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("RedGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Remove White from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("WhiteGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Add all the gamePieces to array
            twoPlayers.SetActive(true);
            gamePieces = new GameObject[30];
            int counter = 0;
            for (int i = 0; i < 15; i++)
            {
                gamePieces[counter] = GameObject.Find("BlueGamePiece" + i);
                if (i > 9)
                {
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().tag = "teamGreen";
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = true;
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<Renderer>().material.color = Color.blue;
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Color = 1;
                }
                counter++;
            }
            for (int i = 0; i < 15; i++)
            {
                gamePieces[counter] = GameObject.Find("GreenGamePiece" + i);
                if (i > 9)
                {
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().tag = "teamBlue";
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = true;
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<Renderer>().material.color = Color.green;
                    gamePieces[counter].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Color = 4;
                }
                counter++;
            }
            playerScript.GameStart = true;
        }
        //----------------------------------------------------------------------GameSetupThreePlayers--------------------------------------------------------------------
        else if (numbersOfPlayers == NumbersOfPlayers.threePlayers)
        {
            //Remove Green from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("GreenGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Remove yellow from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("YellowGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Remove Balck from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("BlackGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Add all the gamePieces to array
            gamePieces = new GameObject[30];
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("BlueGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("WhiteGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("RedGamePiece" + i);
                counter++;
            }
            playerScript.GameStart = true;
        }
        //----------------------------------------------------------------------GameSetupForePlayers--------------------------------------------------------------------
        else if (numbersOfPlayers == NumbersOfPlayers.forePlayers)
        {
            //Remove red from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("RedGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Remove yellow from board.
            for (int i = 0; i < 10; i++)
            {
                GameObject temp = GameObject.Find("YellowGamePiece" + i);
                temp.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.SetActive(false);
            }
            //Add all the gamePieces to array
            gamePieces = new GameObject[40];
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("BlueGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("WhiteGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("GreenGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("BlackGamePiece" + i);
                counter++;
            }
            playerScript.GameStart = true;
        }
        //----------------------------------------------------------------------GameSetupSixPlayers--------------------------------------------------------------------
        else if (numbersOfPlayers == NumbersOfPlayers.sixPlayers)
        {
            //Add all the gamePieces to array
            gamePieces = new GameObject[60];
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("BlueGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("YellowGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("WhiteGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("GreenGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("RedGamePiece" + i);
                counter++;
            }
            for (int i = 0; i < 10; i++)
            {
                gamePieces[counter] = GameObject.Find("BlackGamePiece" + i);
                counter++;
            }
            playerScript.GameStart = true;
        }
        playerScript.GamePieces = gamePieces;
    }
}
