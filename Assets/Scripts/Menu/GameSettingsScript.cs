using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameSettingsScript : MonoBehaviour
{
    private bool blueAI; //If true the AI is on otherwise the AI is off
    private bool yellowAI = true;
    private bool whiteAI = true;
    private bool greenAI = true;
    private bool redAI = true;
    private bool blackAI = true;

    private NumbersOfPlayers numbersOfPlayers;

    //----------------------------------------------------AIs on or off----------------------------------------------
    public bool BlueAI
    {
        get { return blueAI; }
        set { blueAI = value; }
    }
    public bool YellowAI
    {
        get { return yellowAI; }
        set { yellowAI = value; }
    }
    public bool WhiteAI
    {
        get { return whiteAI; }
        set { whiteAI = value; }
    }
    public bool GreenAI
    {
        get { return greenAI; }
        set { greenAI = value; }
    }
    public bool RedAI
    {
        get { return redAI; }
        set { redAI = value; }
    }
    public bool BlackAI
    {
        get { return blackAI; }
        set { blackAI = value; }
    }
    //----------------------------------------------------Player amount----------------------------------------------
    public NumbersOfPlayers NumbersOfPlayers 
    {
        get { return numbersOfPlayers; }
        set { numbersOfPlayers = value; }
    }
}
