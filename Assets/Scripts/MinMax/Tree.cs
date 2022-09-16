using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{
    public GameObject Move;
    public GameObject GamePiece;
    public int point;
    public List<Tree> children;

    public Tree(GameObject GamePiece, GameObject Move)
    {
        this.GamePiece = GamePiece;
        this.Move = Move;
    }

    public void Add(Tree child)
    {
        if (children == null)
            children = new List<Tree>();
        children.Add(child);
    }
}
