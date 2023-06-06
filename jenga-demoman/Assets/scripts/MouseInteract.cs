using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 worldPos;
    public LayerMask layer;
    GameObject lastPiece;
    Vector3 InitMousePos;
    void Update()
    {
<<<<<<< HEAD
        mousePos = Input.mousePosition;//position of mouse on screen
        Ray ray = Camera.main.ScreenPointToRay(mousePos);//raycast of where the funnymouse cursor is
        if (Input.GetKey(KeyCode.Mouse0) && lastPiece != null)//if the mouse is down && lastpeice isnt null, move stored gameobject
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))//store initial position of mousepos
            {
                InitMousePos = mousePos;//initial mouse position, sub from mouse pos to get movement along face vector
            }
            //piece math stuff :)
            Vector3 temp = worldPos - lastPiece.transform.position;//position of last piece
            Vector3 temp2 = new Vector3(lastPiece.transform.forward.z, 0, lastPiece.transform.forward.x);//90 degrie rot of lastpeice
            float FB = Vector3.Dot(temp, lastPiece.transform.forward);  //forward / back
            float LR = Vector3.Dot(temp, temp2);                        //left / rigth
            //movement things
            float moveNumb = (mousePos.x - InitMousePos.x) + (mousePos.y - InitMousePos.y);
            //Debug.Log(temp + ", " + lastPiece.transform.forward + ", " + FB + ", " + LR);//debug line
            Debug.Log(InitMousePos + ", " + mousePos + ", " + moveNumb);
            if(FB >= 0.49f && LR <= 1.6f && LR >= -1.6f)//checks for each side of the pieces, need to dissable the top grabbing
            {
                Debug.Log("sphere on front");
                if(moveNumb > 1 || moveNumb < -1)
                    lastPiece.transform.position = lastPiece.transform.forward * moveNumb;
            }
            else if (FB <= 0.49f && LR <= 1.6f && LR >= -1.6f)
            {
                Debug.Log("sphere on back");
            }
            else if (LR >= 1.6f)//dont need to do a check for FB bc its been checked already
            {
                Debug.Log("sphere on left");
            }
            else if (LR <= -1.6f)
            {
                Debug.Log("sphere on right");
            }
        }
        else if (Physics.Raycast(ray, out RaycastHit hitData, 100000, layer))//else, cast a raycast that stores the most recent hit gameobject's transform
        {
            worldPos = hitData.point;//for sphere indicator, change later
=======
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hitData, 1000, layer))
        {
            Debug.Log("hitting a block!!!");
            worldPos = hitData.point;
>>>>>>> parent of 3d1130b (Merge branch 'main' of https://github.com/rustedCal/Jenga-demolition)
        }

        transform.position = worldPos;//for sphere indicator
    }
    private void OnTriggerStay(Collider other)//gets most recent piece
    {
        lastPiece = other.gameObject;
        //Debug.Log(lastPiece.name);
    }
}
