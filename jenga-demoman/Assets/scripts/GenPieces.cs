using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPieces : MonoBehaviour
{
    public GameObject devPiece;
    public float startY = 0.5f;
    public float yGap = 0.1f;
    public float yHeight = 0.8f;
    public float xGap = 0.25f;
    public int layers = 10;

    void Start()
    {
        
        genPieces();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void genPieces()
    {
        Debug.Log("staring genoration");
        float y = startY;
        bool isRotated = false;
        for (int i = 0; i < layers; i++)
        {
            if (isRotated)
            {
                GameObject peice1 = Instantiate(devPiece, new Vector3(0.0f, startY, 0.0f), Quaternion.identity);
                GameObject peice2 = Instantiate(devPiece, new Vector3(xGap + 1, startY, 0.0f), Quaternion.identity);
                GameObject peice3 = Instantiate(devPiece, new Vector3(-(xGap + 1), startY, 0.0f), Quaternion.identity);
                peice1.transform.rotation.Set(0.0f, 90.0f, 0.0f, peice1.transform.rotation.w);
                peice2.transform.rotation.Set(0.0f, 90.0f, 0.0f, peice2.transform.rotation.w);
                peice3.transform.rotation.Set(0.0f, 90.0f, 0.0f, peice3.transform.rotation.w);
            }
            else
            {
                GameObject peice1 = Instantiate(devPiece, new Vector3(0.0f, startY, 0.0f), Quaternion.identity);
                GameObject peice2 = Instantiate(devPiece, new Vector3(0.0f, startY, xGap + 1), Quaternion.identity);
                GameObject peice3 = Instantiate(devPiece, new Vector3(0.0f, startY, -(xGap + 1)), Quaternion.identity);
            }
            y += yHeight + yGap;
        }
    }
}
