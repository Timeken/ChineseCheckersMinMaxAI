using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxScript : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private List<MovesDoneList> movesDoneList = new List<MovesDoneList>();
    private bool done = false;
    private int maxMovesFailed;
    private PointValueScript pointValue;
    private GameSettingsScript settingsScript;

    private void Start()
    {
        pointValue = camera.GetComponent<PointValueScript>();
        settingsScript = camera.GetComponent<GameSettingsScript>();
    }
    public void MinMaxStart(GameObject[] gamePieces, string turnTag)
    {
        List<MinMaxList> minMaxList = new List<MinMaxList>();
        List<MovementList> movment = new List<MovementList>();
        GameObject[] teamPieces;
        //Check if there are 2 players use 15 gamepieces per team, if not then use 10.
        if (settingsScript.NumbersOfPlayers == NumbersOfPlayers.twoPlayers)
        {
            teamPieces = new GameObject[15];
            maxMovesFailed = 10;
        }
        else
        {
            teamPieces = new GameObject[10];
            maxMovesFailed = 5;
        }
        if (!done)
        {
            //Add the square the gamepiece is standing on to the list of moves alredy done.
            for (int i = 0; i < gamePieces.Length; i++)
            {
                MovesDoneList movesDone = new MovesDoneList
                {
                    GamePiece = gamePieces[i],
                };
                movesDone.MovesDone = new List<GameObject>
                {
                    gamePieces[i].GetComponent<GamePieceScript>().Occuping
                };
                movesDoneList.Add(movesDone);                
            }
            done = true;
        }
        //Add the gamepieces to the teampieces based on what turn it is. 
        int counter = 0;
        for (int i = 0; i < gamePieces.Length; i++)
        {
            if (gamePieces[i].tag.Equals(turnTag))
            {
                teamPieces[counter] = gamePieces[i];                          
                counter++;
            }
        }
        //Send all teampieces through the MiniMax algorithms and add them to a list with the best score and move.
        int faliedMoves = 0;
        for (int i = 0; i < teamPieces.Length; i++)
        {          
            if (teamPieces[i].GetComponent<GamePieceScript>().CheckPaths().Count != 0) //Don't need to check if the gamepiece can't move.
            {
                Tree tree = new Tree(teamPieces[i], teamPieces[i].GetComponent<GamePieceScript>().Occuping);
                MovementList movementList = new MovementList();
                List <GameObject> gameObjectList = new List<GameObject>();
                //Check what movesDone list is for what teampieces.
                for (int j = 0; j < movesDoneList.Count; j++)
                {
                    if (movesDoneList[j].GamePiece == teamPieces[i])
                    {
                        gameObjectList = movesDoneList[j].MovesDone;
                        break;
                    }
                }

                tree = MinMax(tree, 3, Int32.MinValue, Int32.MaxValue, true , gameObjectList, turnTag);
                //If tree.children is null then run faliedMoves.This is because MinMax can sometimes return null because the gamepiece have nowhere left to go but on to a space it has already been to.
                //Because of this another gamepiece will be chosen insted. This will continue untill maxMovesFailed is reached whereupon faliedMoves and movesDoneList is reset to avoid all the gamepieces runing out of moves.
                try
                {
                    //Sort the list whit a quicksort algorithm
                    tree.children = tree.children.OrderByDescending(o => o.point).ToList();
                    MinMaxList tempList = new MinMaxList
                    {
                        Move = tree.children[0].Move,
                        CurrentValue = tree.children[0].point,
                        Start = tree.GamePiece
                    };

                    minMaxList.Add(tempList);
                }
                catch (ArgumentNullException)
                {
                    //to prevent the gamepieces from jumping back and forth they are not allowed to jump on the same place twice. This is reset after maxMovesFailed has been reached.
                    faliedMoves++;
                    if (faliedMoves == maxMovesFailed)
                    {
                        done = false;
                        faliedMoves = 0;
                        movesDoneList = new List<MovesDoneList>();
                    }
                }
                           
            }
        }

        //Because this list will never have more than 15 elements in it minMaxList. Sort is using the insertion sort algorithm.
        minMaxList.Sort(delegate (MinMaxList x, MinMaxList y)
        {
            return y.CurrentValue.CompareTo(x.CurrentValue);
        });

        GameObject gameObject = minMaxList[0].Move;
        GameObject gameObjectStart = minMaxList[0].Start;
        
        for (int i = 0; i < movesDoneList.Count; i++)
        {
            if (movesDoneList[i].GamePiece == minMaxList[0].Start)
            {
                movesDoneList[i].MovesDone.Add(minMaxList[0].Move);
                break;
            }
        }
        float hight = 0.05f;
        gameObjectStart.transform.position = gameObject.transform.position + new Vector3(0, hight, 0);
        gameObjectStart.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
        gameObject.GetComponent<BoardScript>().Occupied = true;
        gameObjectStart.GetComponent<GamePieceScript>().Occuping = gameObject;      
    }
//------------------------------------------------------------------MINIMAX------------------------------------------------------------------   
    public Tree MinMax(Tree node, int depth, int alpha, int beta, bool minMax, List<GameObject> gameObjectList, string turnTag)
    {
        if (depth == 0 || node.point == Int32.MaxValue || node.point == Int32.MinValue)
        {
            node.point = pointValue.PointValue(turnTag);          
            return node;
        }
//------------------------------------------------------------------MAX------------------------------------------------------------------        
        if (minMax)
        {
            node.point = Int32.MinValue;
            List<GameObject> moves = new List<GameObject>();
            //Genarate all moves from position
            moves = node.GamePiece.GetComponent<GamePieceScript>().CheckPaths();
            for(int i = 0; i < gameObjectList.Count; i++)
            {
                moves.Remove(gameObjectList[i]);
            }
            for (int i = 0; i < moves.Count; i++)
            {

                GameObject gameObject = moves[i];
                GameObject gameObjectStart = node.GamePiece;

                GameObject temp = gameObjectStart.GetComponent<GamePieceScript>().Occuping;
                //Move the gamepice to new position
                gameObjectStart.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                gameObject.GetComponent<BoardScript>().Occupied = true;
                gameObjectStart.GetComponent<GamePieceScript>().Occuping = gameObject;
                //Take the gamepiece and the move and make it a child
                Tree child = new Tree(gameObjectStart, moves[i]);
                try
                {
                    //recursive function
                    node.Add(MinMax(child, depth - 1, alpha, beta, false, gameObjectList, turnTag));
                    node.point = Math.Max(node.point, node.children[i].point);
                    alpha = Math.Max(alpha, node.children[i].point);
                }
                catch (ArgumentOutOfRangeException)
                {
                    node.point = Math.Max(node.point, Int32.MinValue);
                    alpha = Math.Max(alpha, Int32.MinValue);
                }
                //Move back the gamepiece to old position
                gameObjectStart.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.GetComponent<BoardScript>().Occupied = true;
                gameObjectStart.GetComponent<GamePieceScript>().Occuping = temp;

                if (beta <= alpha)
                    break;              
            }
            return node;
        }
//----------------------------------------------------------MIN------------------------------------------------------------------
        else
        {
            node.point = Int32.MaxValue;
            List<GameObject> moves = new List<GameObject>();
            //Genarate all moves from position
            moves = node.GamePiece.GetComponent<GamePieceScript>().CheckPaths();
            for (int i = 0; i < gameObjectList.Count; i++)
            {
                moves.Remove(gameObjectList[i]);
            }
            for (int i = 0; i < moves.Count; i++)
            {         
                GameObject gameObject = moves[i];
                GameObject gameObjectStart = node.GamePiece;

                GameObject temp = gameObjectStart.GetComponent<GamePieceScript>().Occuping;
                //Move the gamepice to new position
                gameObjectStart.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                gameObject.GetComponent<BoardScript>().Occupied = true;
                gameObjectStart.GetComponent<GamePieceScript>().Occuping = gameObject;
                //Take the gamepiece and the move and make it a child
                Tree child = new Tree(gameObjectStart, moves[i]);
                try
                {
                    //recursive function
                    node.Add(MinMax(child, depth - 1, alpha, beta, true, gameObjectList, turnTag));
                    node.point = Math.Min(node.point, node.children[i].point);
                    beta = Math.Min(beta, node.children[i].point);
                }
                catch (ArgumentOutOfRangeException)
                {
                    node.point = Math.Min(node.point, 0);
                    beta = Math.Min(beta, 0);
                }
                //Move back the gamepiece to old position
                gameObjectStart.GetComponent<GamePieceScript>().Occuping.GetComponent<BoardScript>().Occupied = false;
                temp.GetComponent<BoardScript>().Occupied = true;
                gameObjectStart.GetComponent<GamePieceScript>().Occuping = temp;

                if (beta <= alpha)
                    break;
                }           
            return node;
        }
    }
}

