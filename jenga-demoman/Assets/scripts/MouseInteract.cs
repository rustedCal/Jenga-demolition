using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public GameObject camRot;
    public Vector3 mousePos;
    public Vector3 worldPos;
    public LayerMask layer;
    public float moveForce = 0.25f;
    GameObject lastPiece;
    Rigidbody lastPieceRigid;
    Vector3 InitMousePos;
    Vector3 InitPiecePos;
    bool canCollide = true;
    bool workdamit;
    Vector3 temp;
    Vector3 forwardRot;
    float FB = 0.0f;
    float LR = 0.0f;
    void Update()
    {
        mousePos = Input.mousePosition;//position of mouse on screen
        Ray ray = Camera.main.ScreenPointToRay(mousePos);//raycast of where the funnymouse cursor is
        if(lastPiece != null)
        {
            lastPieceRigid = lastPiece.GetComponent<Rigidbody>();
            lastPieceRigid.useGravity = true;
        }
        if (Input.GetKey(KeyCode.Mouse0) && lastPiece != null)//if the mouse is down && lastpeice isnt null, move stored gameobject
        {
            lastPieceRigid.useGravity = false;//turn off grav so that werd stuff dont happen
            canCollide = false;
            if (Input.GetKeyDown(KeyCode.Mouse0))//store initial position of mousepos
            {
                InitMousePos = mousePos;//initial mouse position, sub from mouse pos to get movement along face vector
                InitPiecePos = lastPiece.transform.position;
                //--===piece math stuff :), run once for the face detection. we want the initiual piece, not current so that y here===--//
                temp = worldPos - lastPiece.transform.position;//position of last piece
                forwardRot = new Vector3(lastPiece.transform.forward.z, 0, lastPiece.transform.forward.x);//90 degrie rot of lastpeice
                FB = Vector3.Dot(temp, lastPiece.transform.forward);  //forward / back
                LR = Vector3.Dot(temp, forwardRot);                        //left / rigth
                Debug.Log(temp + ", " + lastPiece.transform.forward + ", " + FB + ", " + LR);//debug line
            }
            //movement things
            float moveNumb = (mousePos.x - InitMousePos.x) + (mousePos.y - InitMousePos.y);//the diffrence of where the mosue was to where it is now
            //Debug.Log(InitMousePos + ", " + mousePos + ", " + moveNumb);
            //---==FRONT===--//
            if (FB >= 0.49f && LR <= 1.6f && LR >= -1.6f)//checks for each side of the pieces, need to dissable the top grabbing
            {
                Debug.Log("sphere on front");
                if (moveNumb > moveForce || moveNumb < -moveForce)
                {
                    if(camRot.transform.rotation.eulerAngles.y != 0)//dirty fix for the camera rotation problem, i had to ut the cam into a fixed position for this
                    {//could re-ad the smooth rotation by haviung > and < things, buit this good 4 now. Need to make the placem,ent stuff
                        if (lastPiece.tag == "piece")//SO, this is a dirty fix, and wonr work when the camera rotates
                            lastPiece.transform.position = -lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                        else
                            lastPiece.transform.position = lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                    }
                    else
                    {
                        if (lastPiece.tag == "piece")//SO, this is a dirty fix, and wonr work when the camera rotates
                            lastPiece.transform.position = lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                        else
                            lastPiece.transform.position = -lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                    }
                    
                    Debug.Log(lastPiece.transform.forward + ", " +", " + camRot.transform.rotation.eulerAngles.y + ", " + (camRot.transform.rotation.eulerAngles.y != 0));
                }
            }
            //--===BACK===--//
            else if (FB <= 0.49f && LR <= 1.6f && LR >= -1.6f)
            {
                Debug.Log("sphere on back");
                if (moveNumb > moveForce || moveNumb < -moveForce)
                {
                    if (moveNumb > moveForce || moveNumb < -moveForce)
                    {
                        if (camRot.transform.rotation.eulerAngles.y != 180.0f)//dirty fix for the camera rotation problem, i had to ut the cam into a fixed position for this
                        {//could re-ad the smooth rotation by haviung > and < things, buit this good 4 now. Need to make the placem,ent stuff
                            if (lastPiece.tag == "piece")//SO, this is a dirty fix, and wonr work when the camera rotates
                                lastPiece.transform.position = lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                            else
                                lastPiece.transform.position = -lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                        }
                        else
                        {
                            if (lastPiece.tag == "piece")//SO, this is a dirty fix, and wonr work when the camera rotates
                                lastPiece.transform.position = -lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                            else
                                lastPiece.transform.position = lastPiece.transform.forward * (moveNumb * moveForce) + InitPiecePos;
                        }
                    }
                    Debug.Log(lastPiece.transform.forward + ", " + ", " + camRot.transform.rotation.eulerAngles.y + ", " + (camRot.transform.rotation.eulerAngles.y != 180));
                }
            }
            //--===LEFT===--//
            else if (LR >= 1.6f)//dont need to do a check for FB bc its been checked already
            {
                Debug.Log("sphere on left");
                if (moveNumb > moveForce || moveNumb < -moveForce)
                {
                    if (moveNumb > moveForce || moveNumb < -moveForce)
                    {
                        if (camRot.transform.rotation.eulerAngles.y != 90.0f && camRot.transform.rotation.eulerAngles.y != 270)//dirty fix for the camera rotation problem, i had to ut the cam into a fixed position for this
                        {//could re-ad the smooth rotation by haviung > and < things, buit this good 4 now. Need to make the placem,ent stuff
                            lastPiece.transform.position = -lastPiece.transform.right * (moveNumb * moveForce) + InitPiecePos;
                        }
                        else
                        {
                            lastPiece.transform.position = lastPiece.transform.right * (moveNumb * moveForce) + InitPiecePos;
                        }
                    }
                    Debug.Log(lastPiece.transform.right + ", " +  ", " + camRot.transform.rotation.eulerAngles.y + ", " + (camRot.transform.rotation.eulerAngles.y != 90.0f && camRot.transform.rotation.eulerAngles.y != 270));
                }
            }
            //--===RIGHT===--//
            else if (LR <= -1.6f)
            {
                Debug.Log("sphere on right");
                if (moveNumb > moveForce || moveNumb < -moveForce)
                {
                    if (moveNumb > moveForce || moveNumb < -moveForce)
                    {
                        if (camRot.transform.rotation.eulerAngles.y != 90.0f && camRot.transform.rotation.eulerAngles.y != 270)//dirty fix for the camera rotation problem, i had to ut the cam into a fixed position for this
                        {//could re-ad the smooth rotation by haviung > and < things, buit this good 4 now. Need to make the placem,ent stuff
                            lastPiece.transform.position = lastPiece.transform.right * (moveNumb * moveForce) + InitPiecePos;
                        }
                        else
                        {
                            lastPiece.transform.position = -lastPiece.transform.right * (moveNumb * moveForce) + InitPiecePos;
                        }
                    }
                    Debug.Log(lastPiece.transform.right + ", " + ", " + camRot.transform.rotation.eulerAngles.y + ", " + (camRot.transform.rotation.eulerAngles.y != 90.0f && camRot.transform.rotation.eulerAngles.y != 270));
                }
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
