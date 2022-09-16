using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    private List<GameObject> movesChecked;

    public List<GameObject> MovesChecked 
    {
        get { return movesChecked; }
        set { movesChecked = value; }
    }

    void Start()
    {
        movesChecked = new List<GameObject>();
    }

    void CheckJumpPath(GameObject[] jump, GameObject start) //Checking if there is any posible gamePieces to jump over.
    {
        for (int i = 0; i < jump.Length; i++)
        {
            if (jump[i] == start)
            {
                switch (i) //Check what direction the gamePiece is comming from so that it jumps the right way.
                {
                    case 0:
                        if (!movesChecked.Contains(jump[5]) && jump[5] != null && !jump[5].GetComponent<BoardScript>().Occupied)
                        {
                            movesChecked.Add(jump[5]);
                            CheckJump(jump[5].GetComponent<BoardScript>().Neighbors, jump[5]);
                        }
                        break;
                    case 1:
                        if (!movesChecked.Contains(jump[4]) && jump[4] != null && !jump[4].GetComponent<BoardScript>().Occupied)
                        {
                            movesChecked.Add(jump[4]);
                            CheckJump(jump[4].GetComponent<BoardScript>().Neighbors, jump[4]);
                        }
                        break;
                    case 2:
                        if (!movesChecked.Contains(jump[3]) && jump[3] != null && !jump[3].GetComponent<BoardScript>().Occupied)
                        {
                            movesChecked.Add(jump[3]);
                            CheckJump(jump[3].GetComponent<BoardScript>().Neighbors, jump[3]);
                        }
                        break;
                    case 3:
                        if (!movesChecked.Contains(jump[2]) && jump[2] != null && !jump[2].GetComponent<BoardScript>().Occupied)
                        {
                            movesChecked.Add(jump[2]);
                            CheckJump(jump[2].GetComponent<BoardScript>().Neighbors, jump[2]);
                        }
                        break;
                    case 4:
                        if (!movesChecked.Contains(jump[1]) && jump[1] != null && !jump[1].GetComponent<BoardScript>().Occupied)
                        {
                            movesChecked.Add(jump[1]);
                            CheckJump(jump[1].GetComponent<BoardScript>().Neighbors, jump[1]);
                        }
                        break;
                    case 5:
                        if (!movesChecked.Contains(jump[0]) && jump[0] != null && !jump[0].GetComponent<BoardScript>().Occupied)
                        {
                            movesChecked.Add(jump[0]);
                            CheckJump(jump[0].GetComponent<BoardScript>().Neighbors, jump[0]);
                        }
                        break;
                }
            }
        }
    }

    void CheckJump(GameObject[] jump, GameObject start) //If there are any posible gamePieces to jump over, check if there are more after that.
    {
        for (int i = 0; i < jump.Length; i++)
        {
            if (jump[i] != null && jump[i].GetComponent<BoardScript>().Occupied)
            {
                GameObject[] jumpPaths;
                jumpPaths = jump[i].GetComponent<BoardScript>().Neighbors;
                CheckJumpPath(jumpPaths, start);                
            }
        }
    }

    public List<GameObject> Paths(GameObject[] checkPaths,GameObject occuping) //Checking all possible moves.
    {
        for (int i = 0; i < checkPaths.Length; i++)
        {
            if (checkPaths[i] != null)
            {
                if (!checkPaths[i].GetComponent<BoardScript>().Occupied && checkPaths[i] != null)
                {
                    movesChecked.Add(checkPaths[i]);
                }
                else if (checkPaths[i].GetComponent<BoardScript>().Occupied && checkPaths[i] != null)
                {
                    GameObject[] jumpPaths;
                    jumpPaths = checkPaths[i].GetComponent<BoardScript>().Neighbors;
                    CheckJumpPath(jumpPaths, occuping);
                }
            }
        }
        return movesChecked;
    }
}
