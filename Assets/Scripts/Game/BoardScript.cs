using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {

    [SerializeField]
    private bool occupied;
    [SerializeField]
    private GameObject[] neighbors;
    [SerializeField]
    private int color; //0 grey, 1 blue, 2 yellow, 3 white, 4 green, 5 red, 6 black.
    public bool Occupied
    {
        get { return occupied; }
        set { occupied = value; }
    }
    public GameObject[] Neighbors
    {
        get { return neighbors; }
        set { neighbors = value; }
    }
    public int Color
    {
        get { return color; }
        set { color = value; }
    }
}
