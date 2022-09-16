using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointValueScript : MonoBehaviour 
{

    [SerializeField]
    private Camera camera;

    GameObject[] teamPieces = new GameObject[15];

    private PlayerScript playerScript;
    private GameSettingsScript settingsScript;

    private void Start()
    {
        playerScript = camera.GetComponent<PlayerScript>();
        settingsScript = camera.GetComponent<GameSettingsScript>();
    }

    public int PointValue(string turnTag)
    {
        if (settingsScript.NumbersOfPlayers != NumbersOfPlayers.twoPlayers)
        {
            teamPieces = new GameObject[10];
        }

        int point = 0;
        int counter = 0;

        for (int i = 0; i < playerScript.GamePieces.Length; i++)
        {
            if (turnTag.Equals(Turn.teamBlue.ToString()))
            {
                if (playerScript.GamePieces[i].name.Equals("BlueGamePiece" + counter))
                {
                    teamPieces[counter] = playerScript.GamePieces[i];
                    counter++;
                }
            }
            else if (turnTag.Equals(Turn.teamYellow.ToString()))
            {
                if (playerScript.GamePieces[i].name.Equals("YellowGamePiece" + counter))
                {
                    teamPieces[counter] = playerScript.GamePieces[i];
                    counter++;
                }
            }
            else if (turnTag.Equals(Turn.teamWhite.ToString()))
            {
                if (playerScript.GamePieces[i].name.Equals("WhiteGamePiece" + counter))
                {
                    teamPieces[counter] = playerScript.GamePieces[i];
                    counter++;
                }
            }
            else if (turnTag.Equals(Turn.teamGreen.ToString()))
            {
                if (playerScript.GamePieces[i].name.Equals("GreenGamePiece" + counter))
                {
                    teamPieces[counter] = playerScript.GamePieces[i];
                    counter++;
                }
            }
            else if (turnTag.Equals(Turn.teamRed.ToString()))
            {
                if (playerScript.GamePieces[i].name.Equals("RedGamePiece" + counter))
                {
                    teamPieces[counter] = playerScript.GamePieces[i];
                    counter++;
                }
            }
            else if (turnTag.Equals(Turn.teamBlack.ToString()))
            {
                if (playerScript.GamePieces[i].name.Equals("BlackGamePiece" + counter))
                {
                    teamPieces[counter] = playerScript.GamePieces[i];
                    counter++;
                }
            }
            if (counter == 10 && settingsScript.NumbersOfPlayers != NumbersOfPlayers.twoPlayers)
            {
                break;
            }
            else if (counter == 15 && settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers)
            {
                break;
            }
        }
        //Calculate point value for all team pieces moves
        for (int i = 0; i < teamPieces.Length; i++) {
            if (turnTag.Equals(Turn.teamBlue.ToString()))
            {
                if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board5") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board11") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board18") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board26") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board35"))
                {
                    point += 1;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board4") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board10") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board17") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board25") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board34") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board43"))
                {
                    point += 2;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board9") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board16") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board24") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board33") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board42")
                    || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board50"))
                {
                    point += 3;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board2") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board8") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board15") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board23") || 
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board32") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board41") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board49") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board56"))
                {
                    point += 4;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board7") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board14") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board22") || 
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board31") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board40") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board48") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board55") || 
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board61"))
                {
                    point += 5;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board13") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board21") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board30") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board39") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board47") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board54") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board60"))
                {
                    point += 6;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board12") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board20") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board29") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board38") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board46") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board53") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board59"))
                {
                    point += 7;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board19") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board28") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board37") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board45") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board52") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board58"))
                {
                    point += 8;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board27") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board36") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board44") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board51") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board57"))
                {
                    point += 9;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard10") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard9") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard8") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard7"))
                {
                    point += 10;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard5") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard4"))
                {
                    point += 11;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard2"))
                {
                    point += 12;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamGreenBoard1"))
                {
                    point += 13;
                }               
            }
            if (turnTag.Equals(Turn.teamYellow.ToString()))
            {
                if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board2") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board4") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board5"))
                {
                    point += 1;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board7") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board8") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board9") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board10") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1"))
                {
                    point += 2;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board12") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board13") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board14") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board15") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board16") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board17")
                    || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board18"))
                {
                    point += 3;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board19") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board20") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board21") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board22") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board23") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board24") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board25") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board26"))
                {
                    point += 4;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board27") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board28") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board29") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board30") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board31") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board32") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board33") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board34") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board35"))
                {
                    point += 5;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board36") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board37") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board38") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board39") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board40") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board41") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board42") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board43"))
                {
                    point += 6;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board44") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board45") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board46") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board47") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board48") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board49") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board50"))
                {
                    point += 7;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board51") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board52") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board53") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board54") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board55") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board56"))
                {
                    point += 8;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board57") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board58") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board59") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board60") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board61"))
                {
                    point += 9;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard7") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard8") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard9") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard10"))
                {
                    point += 10;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard5") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard4"))
                {
                    point += 11;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard2"))
                {
                    point += 12;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamRedBoard1"))
                {
                    point += 13;
                }
            }
            if (turnTag.Equals(Turn.teamWhite.ToString()))
            {
                if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board27") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board19") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board12") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board6") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1"))
                {
                    point += 1;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board36") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board28") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board20") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board13") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board7") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board2"))
                {
                    point += 2;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board44") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board37") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board29") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board21") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board14") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board8")
                    || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board3"))
                {
                    point += 3;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board51") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board45") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board38") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board30") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board22") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board15") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board9") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board4"))
                {
                    point += 4;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board57") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board52") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board46") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board39") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board31") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board23") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board16") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board10") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board5"))
                {
                    point += 5;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board58") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board53") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board47") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board40") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board32") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board24") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board17") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board11"))
                {
                    point += 6;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board59") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board54") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board48") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board41") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board33") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board25") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board18"))
                {
                    point += 7;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board60") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board55") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board49") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board42") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board34") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board26"))
                {
                    point += 8;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board61") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board56") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board50") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board43") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board35"))
                {
                    point += 9;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard7") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard8") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard9") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard10"))
                {
                    point += 10;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard5") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard4"))
                {
                    point += 11;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard2"))
                {
                    point += 12;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard1"))
                {
                    point += 13;
                }
            }
            if (turnTag.Equals(Turn.teamGreen.ToString()))
            {        
                if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board5") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board11") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board18") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board26") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board35"))
                {
                    point += 9;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board4") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board10") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board17") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board25") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board34") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board43"))
                {
                    point += 8;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board9") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board16") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board24") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board33") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board42")
                    || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board50"))
                {
                    point += 7;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board2") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board8") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board15") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board23") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board32") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board41") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board49") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board56"))
                {
                    point += 6;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board7") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board14") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board22") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board31") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board40") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board48") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board55") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board61"))
                {
                    point += 5;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board13") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board21") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board30") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board39") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board47") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board54") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board60"))
                {
                    point += 4;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board12") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board20") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board29") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board38") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board46") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board53") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board59"))
                {
                    point += 3;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board19") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board28") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board37") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board45") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board52") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board58"))
                {
                    point += 2;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board27") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board36") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board44") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board51") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board57"))
                {
                    point += 1;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard10") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard9") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard8") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard7"))
                {
                    point += 10;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard5") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard4"))
                {
                    point += 11;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard2"))
                {
                    point += 12;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlueBoard1"))
                {
                    point += 13;
                }
                if(settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && teamPieces[i].GetComponent<GamePieceScript>().Occuping.tag.Equals("teamRed")|| settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && teamPieces[i].GetComponent<GamePieceScript>().Occuping.tag.Equals("teamYellow")||
                    settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && teamPieces[i].GetComponent<GamePieceScript>().Occuping.tag.Equals("teamBlack") || settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers && teamPieces[i].GetComponent<GamePieceScript>().Occuping.tag.Equals("teamWhite"))
                {
                    point = -100;
                }
            }
            if (turnTag.Equals(Turn.teamRed.ToString()))
            {
                if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board2") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board4") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board5"))
                {
                    point += 9;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board7") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board8") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board9") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board10") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1"))
                {
                    point += 8;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board12") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board13") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board14") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board15") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board16") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board17")
                    || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board18"))
                {
                    point += 7;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board19") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board20") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board21") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board22") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board23") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board24") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board25") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board26"))
                {
                    point += 6;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board27") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board28") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board29") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board30") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board31") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board32") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board33") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board34") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board35"))
                {
                    point += 5;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board36") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board37") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board38") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board39") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board40") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board41") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board42") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board43"))
                {
                    point += 4;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board44") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board45") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board46") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board47") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board48") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board49") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board50"))
                {
                    point += 3;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board51") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board52") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board53") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board54") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board55") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board56"))
                {
                    point += 2;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board57") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board58") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board59") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board60") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board61"))
                {
                    point += 1;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard7") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard8") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard9") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard10"))
                {
                    point += 10;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard5") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard4"))
                {
                    point += 11;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard2"))
                {
                    point += 12;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamYellowBoard1"))
                {
                    point += 13;
                }
            }
            if (turnTag.Equals(Turn.teamBlack.ToString()))
            {
                if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard2"))
                {
                    point += -5;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamBlackBoard1"))
                {
                    point += -10;
                }

                if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board27") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board19") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board12") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board6") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board1"))
                {
                    point += 9;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board36") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board28") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board20") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board13") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board7") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board2"))
                {
                    point += 8;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board44") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board37") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board29") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board21") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board14") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board8")
                    || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board3"))
                {
                    point += 7;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board51") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board45") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board38") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board30") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board22") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board15") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board9") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board4"))
                {
                    point += 6;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board57") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board52") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board46") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board39") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board31") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board23") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board16") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board10") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board5"))
                {
                    point += 5;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board58") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board53") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board47") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board40") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board32") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board24") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board17") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board11"))
                {
                    point += 4;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board59") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board54") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board48") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board41") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board33") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board25") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board18"))
                {
                    point += 3;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board60") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board55") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board49") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board42") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board34") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board26"))
                {
                    point += 2;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board61") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board56") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board50") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board43") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("Board35"))
                {
                    point += 1;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard7") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard8") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard9") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard10"))
                {
                    point += 10;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard6") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard5") ||
                    teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard4"))
                {
                    point += 11;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard3") || teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard2"))
                {
                    point += 12;
                }
                else if (teamPieces[i].GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().gameObject.name.Equals("teamWhiteBoard1"))
                {
                    point += 13;
                }
            }                   
        }       
        return point;
    }

}
