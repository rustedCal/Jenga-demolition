using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeBlock : MonoBehaviour
{
    public GameObject devPiece;
    public GenPieces genSript;
    float yHeight;
    int blockPlaced = 0;
    bool rotated = false;
    //get the starting y height + the y gap & height
    void Start()
    {
        yHeight = genSript.y + genSript.yHeight + genSript.yGap;
    }
    void Update()
    {
        
    }
    void place()
    {

    }
}
