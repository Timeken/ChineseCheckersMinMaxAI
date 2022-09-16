using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinScript : MonoBehaviour {

    [SerializeField]
    GameObject[] gamePieces;
    [SerializeField]
    string zoneColor;

    public bool CheckWin(string turnTag, NumbersOfPlayers numbersOfPlayers)
    {
        bool win = false;
        for (int i = 0; i < gamePieces.Length; i++)
        {
            if(i == 9 && zoneColor.Equals(turnTag) && gamePieces[i].GetComponent<GamePieceScript>().Occuping.tag.Equals(turnTag) && numbersOfPlayers != NumbersOfPlayers.twoPlayers)
            {
                win = true;
            }
            if (i == 14 && zoneColor.Equals(turnTag) && gamePieces[i].GetComponent<GamePieceScript>().Occuping.tag.Equals(turnTag) && numbersOfPlayers == NumbersOfPlayers.twoPlayers)
            {
                win = true;
            }
            else if (!gamePieces[i].GetComponent<GamePieceScript>().Occuping.tag.Equals(turnTag))
            {
                break;
            }
        }
        return win;
    }
}
