using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private GameObject[] colorZones;

    [SerializeField]
    private GameObject GameOverCanvas;   

    List<GameObject> playerMoves;
    GameObject lastPressed;

    private bool playerTurn;

    private MinMaxScript minMax;
    private GameSettingsScript settingsScript;

    private bool gameStart = false;
    private Turn turn;
    private GameObject[] gamePieces;

    public Turn Turn
    {
        get { return turn; }
        set { turn = value; }
    }

    public bool GameStart
    {
        get { return gameStart; }
        set { gameStart = value; }
    }

    public GameObject[] GamePieces
    {
        get { return gamePieces; }
        set { gamePieces = value; }
    }

    void Start()
    {
        turn = Turn.teamBlue;//Blue starts
        settingsScript = camera.GetComponent<GameSettingsScript>();
        minMax = camera.GetComponent<MinMaxScript>();
        playerTurn = true;
        playerMoves = new List<GameObject>();
    }

    void Update()
    {
        if (gameStart)
        {
            if (playerTurn && Input.GetMouseButtonDown(0) && !colorZones[(int)turn - 1].GetComponent<CheckWinScript>().CheckWin(turn.ToString(), settingsScript.NumbersOfPlayers))
            {
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag.Equals(turn.ToString()) && hit.collider.GetComponent<GamePieceScript>() != null) //Check whos turn it is.
                    {
                        if (playerMoves != null && lastPressed != hit.collider.gameObject)
                        {
                            ChangeColor();
                        }
                        lastPressed = hit.collider.gameObject;
                        playerMoves = hit.collider.gameObject.GetComponent<GamePieceScript>().MovesChecked;

                        GameObject[] checkingPaths = playerMoves.ToArray();
                        for (int i = 0; i < checkingPaths.Length; i++)
                        {
                            checkingPaths[i].GetComponent<Renderer>().material.color = Color.magenta;
                        }
                    }
                    else if (playerMoves.Contains(hit.collider.gameObject))
                    {
                        //move the gamePiece to the selected space
                        float hight = 0.05f;
                        lastPressed.transform.position = hit.collider.gameObject.transform.position + new Vector3(0, hight, 0);
                        lastPressed.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                        lastPressed.GetComponent<GamePieceScript>().Occuping = hit.collider.gameObject;

                        ChangeTurn();
                        ChangeColor();

                        lastPressed.GetComponent<GamePieceScript>().MovesChecked = new List<GameObject>();
                        hit.collider.gameObject.GetComponent<BoardScript>().Occupied = true;
                    }

                }

            }
            if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && turn == Turn.teamYellow || settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && turn == Turn.teamWhite || settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && turn == Turn.teamRed || settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && turn == Turn.teamBlack)
            {
                ChangeTurn();
            }
            else if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.threePlayers && turn == Turn.teamYellow || settingsScript.NumbersOfPlayers == NumbersOfPlayers.threePlayers && turn == Turn.teamGreen || settingsScript.NumbersOfPlayers == NumbersOfPlayers.threePlayers && turn == Turn.teamBlack)
            {
                ChangeTurn();
            }
            else if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.forePlayers && turn == Turn.teamYellow || settingsScript.NumbersOfPlayers == NumbersOfPlayers.forePlayers && turn == Turn.teamRed)
            {
                ChangeTurn();
            }
            else if (!playerTurn)
            {
                minMax.MinMaxStart(gamePieces, turn.ToString());
                ChangeTurn();
            }
        }
    }
    //----------------------------------------------------------------------ChangeTurn--------------------------------------------------------------------
    public void ChangeTurn()
    {
        if(colorZones[(int)turn - 1].GetComponent<CheckWinScript>().CheckWin(turn.ToString(), settingsScript.NumbersOfPlayers)) //Check if anyone wins.
        {
            GameOverCanvas.SetActive(true);
            camera.GetComponent<MenuScript>().GameOver(turn.ToString());
        }
        else if (turn == Turn.teamBlue)
        {
            if (!settingsScript.YellowAI)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }
            turn = Turn.teamYellow;
        }
        else if (turn == Turn.teamYellow)
        {
            if (!settingsScript.WhiteAI)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }
            turn = Turn.teamWhite;
        }
        else if (turn == Turn.teamWhite)
        {
            if (!settingsScript.GreenAI)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }
            turn = Turn.teamGreen;
        }
        else if (turn == Turn.teamGreen)
        {
            if (!settingsScript.RedAI)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }
            turn = Turn.teamRed;
        }
        else if (turn == Turn.teamRed)
        {
            if (!settingsScript.BlackAI)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }
            turn = Turn.teamBlack;
        }
        else if (turn == Turn.teamBlack)
        {
            if (!settingsScript.BlueAI)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }
            turn = Turn.teamBlue;
        }
    }
    //----------------------------------------------------------------------ChangeColor--------------------------------------------------------------------
    private void ChangeColor() //Change the board color back to what it was.
    {
        GameObject[] changeColor = playerMoves.ToArray();
        for (int i = 0; i < changeColor.Length; i++)
        {
            switch (changeColor[i].GetComponent<BoardScript>().Color)
            {
                case 0:
                    changeColor[i].GetComponent<Renderer>().material.color = Color.gray;
                    break;
                case 1:
                    changeColor[i].GetComponent<Renderer>().material.color = Color.blue;
                    break;
                case 2:
                    changeColor[i].GetComponent<Renderer>().material.color = Color.yellow;
                    break;
                case 3:
                    changeColor[i].GetComponent<Renderer>().material.color = Color.white;
                    break;
                case 4:
                    changeColor[i].GetComponent<Renderer>().material.color = Color.green;
                    break;
                case 5:
                    changeColor[i].GetComponent<Renderer>().material.color = Color.red;
                    break;
                case 6:
                    changeColor[i].GetComponent<Renderer>().material.color = Color.black;
                    break;
            }
        }
    }
}
