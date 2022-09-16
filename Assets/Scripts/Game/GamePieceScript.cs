using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceScript : MovementScript {

    [SerializeField]
    private GameObject occuping; //Current space that the gamePiece is occuping.    

    public GameObject Occuping
    {
        get { return occuping; }
        set { occuping = value; }
    }

    private void OnMouseDown()
    {
        CheckPaths();
    }

    public List<GameObject> CheckPaths()//Check the paths that the game pice can take.
    {
        GameObject[] paths;
        paths = Occuping.GetComponent<BoardScript>().Neighbors;
        MovesChecked = new List<GameObject>();
        if (paths != null)
        {
            MovesChecked = Paths(paths, Occuping);
        }
        return MovesChecked;
    }

}
