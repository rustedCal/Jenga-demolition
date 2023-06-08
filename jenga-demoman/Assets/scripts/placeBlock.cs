using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeBlock : MonoBehaviour
{
    public GameObject devPiece;
    GameObject currentPiece;
    public GenPieces genSript;
    public isLose loseScript;
    float yHeight;
    int blockPlaced = 0;
    bool rotated;
    //get the starting y height + the y gap & height
    void Start()
    {
        yHeight = genSript.y + genSript.yHeight + genSript.yGap;
        rotated = genSript.isRotated;
    }
    void Update()
    {
        if (loseScript.triggerPlace)
        {
            place();
            loseScript.triggerPlace = false;
        }
    }
    void place()
    {
        if(blockPlaced > 3)
        {
            rotated = !rotated;
            yHeight += genSript.yHeight + genSript.yGap;
        }
        if (rotated)
        {
            GameObject peice = Instantiate(devPiece, new Vector3(0.0f, yHeight, 0.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f));
            currentPiece = peice;
            peice.tag = "pieceRot";
        }
        else
        {
            GameObject peice = Instantiate(devPiece, new Vector3(0.0f, yHeight, 0.0f), Quaternion.identity);
            currentPiece = peice;
        }
        blockPlaced++;
    }
}
