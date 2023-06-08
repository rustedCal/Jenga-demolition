using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeBlock : MonoBehaviour
{
    public GameObject devPiece;
    public GenPieces genSript;
    float yHeight;
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
