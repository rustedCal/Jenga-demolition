using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode rotL = KeyCode.A;
    public KeyCode rotR = KeyCode.D;
    public float speedY = 0.5f;
    public float rotSpeed = 0.5f;

    //cloud stuff
    public GameObject Clouds;
    public float CloudRotSpeed;
    public Vector3 rotationDirection = new Vector3();
    public Vector3 inverseRotationDirection = new Vector3();
    //end cloud stuff

    void FixedUpdate()
    {
        Vector3 temp = gameObject.transform.position;//a temporary vector3 used to get transform inputs to set later
        
        
        if (Input.GetKey(up))//for up / down movement
        {
            temp.y += speedY;
            Clouds.transform.Rotate(CloudRotSpeed * rotationDirection * Time.deltaTime);
            
        }
        else if(Input.GetKey(down) && gameObject.transform.position.y > 0)
        {
            temp.y -= speedY;
            Clouds.transform.Rotate(CloudRotSpeed * inverseRotationDirection * Time.deltaTime);
        }
        
        gameObject.transform.position = temp;//sets camera position
        
    }
    private void Update()
    {
        Clouds.transform.position = gameObject.transform.position;
        float temp2 = gameObject.transform.rotation.eulerAngles.y;
        if (Input.GetKeyDown(rotL))//for left / right rotation
        {
            temp2 += 90;
        }
        else if (Input.GetKeyDown(rotR))
        {
            temp2 -= 90;
        }
        gameObject.transform.rotation = Quaternion.Euler(0, Mathf.Round(temp2), 0);//sets camera rotation
    }
}
