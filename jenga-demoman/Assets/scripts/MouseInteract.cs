using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 worldPos;
    public LayerMask layer;
    GameObject lastPiece;
    void Update()
    {
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if (Input.GetKey(KeyCode.Mouse0) && lastPiece != null)//if the mouse is down && lastpeice isnt null, move stored gameobject
        {
            Vector3 temp = worldPos - lastPiece.transform.position;//position of last piece
            Vector3 temp2 = new Vector3(lastPiece.transform.forward.z, 0, lastPiece.transform.forward.x);//90 degrie rot of lastpeice
            float FB = Vector3.Dot(temp, lastPiece.transform.forward);//forward / back
            float LR = Vector3.Dot(temp, temp2);//left / rigth
            Debug.Log(temp + ", " + lastPiece.transform.forward + ", " + FB + ", " + LR);
            if(FB >= 0.49f && LR <= 1.6f && LR >= -1.6f)
            {
                Debug.Log("sphere on front");
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
        }

        transform.position = worldPos;//for sphere indicator
    }
    private void OnTriggerStay(Collider other)//gets most recent piece
    {
        lastPiece = other.gameObject;
        //Debug.Log(lastPiece.name);
    }
}
