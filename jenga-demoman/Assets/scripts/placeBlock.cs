using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeBlock : MonoBehaviour
{
    public GameObject devPiece;
    GameObject currentPiece;
    public GenPieces genSript;
    public MouseInteract mouse;
    public isLose loseScript;
    public bool placedBlock;//used to dissable mouseinteract(not done) nad to fully place block
    float yHeight;
    int blockPlaced = 1;
    bool rotated;
    //get the starting y height + the y gap & height
    void Start()
    {
        rotated = genSript.isRotated;
    }
    void Update()
    {
        if (genSript.getY)
        {
            yHeight = genSript.y + genSript.yHeight + genSript.yGap;//needs to be called when gen is done
            genSript.getY = false;
            Debug.Log(yHeight);
        }
        if (loseScript.triggerPlace)
        {
            place();
            loseScript.triggerPlace = false;
        }
        if (placedBlock)
        {
            Debug.Log("going into block place mode");
            mouse.enabled = false;
            //curentPiece movement
            Rigidbody temp = currentPiece.GetComponent<Rigidbody>();
            temp.useGravity = false;
            //dropping the block
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("exiting block place mode");
                temp.useGravity = true;
                mouse.enabled = true;
                placedBlock = false;
            }
        }
    }
    void place()
    {
        if(blockPlaced > 3)
        {
            rotated = !rotated;
            yHeight += genSript.yHeight + genSript.yGap;
            blockPlaced = 1;
        }
        Debug.Log("plsacing block w/ y:" + yHeight);
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
        placedBlock = true;
    }
}
