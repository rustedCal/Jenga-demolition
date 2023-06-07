using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 worldPos;
    public LayerMask layer;
    public float moveForce = 0.25f;
    GameObject lastPiece;
    Vector3 InitMousePos;
    Vector3 InitPiecePos;
    bool canCollide = true;
    bool workdamit;
    Vector3 temp;
    Vector3 temp2;
    float FB = 0.0f;
    float LR = 0.0f;
    void Update()
    {
        mousePos = Input.mousePosition;//position of mouse on screen
        Ray ray = Camera.main.ScreenPointToRay(mousePos);//raycast of where the funnymouse cursor is
        if (Input.GetKey(KeyCode.Mouse0) && lastPiece != null)//if the mouse is down && lastpeice isnt null, move stored gameobject
        {
            //Debug.Log("mouse down");
            canCollide = false;
            if (Input.GetKeyDown(KeyCode.Mouse0))//store initial position of mousepos
            {
                InitMousePos = mousePos;//initial mouse position, sub from mouse pos to get movement along face vector
                InitPiecePos = lastPiece.transform.position;
                //--===piece math stuff :), run once for the face detection. we want the initiual piece, not current so that y here===--//
                temp = worldPos - lastPiece.transform.position;//position of last piece
                temp2 = new Vector3(lastPiece.transform.forward.z, 0, lastPiece.transform.forward.x);//90 degrie rot of lastpeice
                FB = Vector3.Dot(temp, lastPiece.transform.forward);  //forward / back
                LR = Vector3.Dot(temp, temp2);                        //left / rigth
                Debug.Log(temp + ", " + lastPiece.transform.forward + ", " + FB + ", " + LR);//debug line
            }
            //movement things
            float moveNumb = (mousePos.x - InitMousePos.x) + (mousePos.y - InitMousePos.y);//the diffrence of where the mosue was to where it is now
            //Debug.Log(InitMousePos + ", " + mousePos + ", " + moveNumb);
            if (FB >= 0.49f && LR <= 1.6f && LR >= -1.6f)//checks for each side of the pieces, need to dissable the top grabbing
            {
                Debug.Log("sphere on front");
                if (moveNumb > moveForce || moveNumb < -moveForce)
                {
                    //the pieces need to move relitive to the camera, use an if statement
                    if(lastPiece.tag == "piece")//becasue the rotated piece's forward vector arent the same, taging them is the best way to dirientiate
                        lastPiece.transform.position = lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                    else
                        lastPiece.transform.position = -lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                    Debug.Log(lastPiece.transform.forward + ", " + moveNumb * moveForce + ", " + (lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos) + ", " + workdamit);
                }
            }
            else if (FB <= 0.49f && LR <= 1.6f && LR >= -1.6f)
            {
                //Debug.Log("sphere on back");
            }
            else if (LR >= 1.6f)//dont need to do a check for FB bc its been checked already
            {
                //Debug.Log("sphere on left");
            }
            else if (LR <= -1.6f)
            {
                //Debug.Log("sphere on right");
            }
        }
        else if (Physics.Raycast(ray, out RaycastHit hitData, 100000, layer))//else, cast a raycast that stores the most recent hit gameobject's transform
        {
            //Debug.Log("casting raycast");
            canCollide = true;
            worldPos = hitData.point;//for sphere indicator, change later
        }
        transform.position = worldPos;//for sphere indicator
    }
    private void OnTriggerStay(Collider other)//gets most recent piece
    {
        if (canCollide)
        {
            //Debug.Log("getting piece");
            lastPiece = other.gameObject;
        }
    }
}
