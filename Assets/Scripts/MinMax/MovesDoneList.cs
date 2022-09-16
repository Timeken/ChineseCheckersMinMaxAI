using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesDoneList 
{
    private GameObject gamePiece;
    private List<GameObject> movesDone;

    public List<GameObject> MovesDone
    {
        get { return movesDone; }
        set { movesDone = value; }
    } 
    public GameObject GamePiece
    {
        get { return gamePiece; }
        set { gamePiece = value; }
    }   

}

