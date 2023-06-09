using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPieces : MonoBehaviour
{
    public GameObject devPiece;
    public float y;
    public float startY = 0.5f;
    public float yGap = 0.1f;
    public float yHeight = 0.8f;
    public float xGap = 0.25f;
    public int layers = 10;
    public bool isRotated = false;
    public bool getY = false;//for the placeblock script, so that it gets the correct y
    void Start()
    {
        genPieces();
    }
    public void genPieces()
    {
        Debug.Log("staring genoration");
        y = startY;
        
        for (int i = 0; i < layers; i++)
        {
            if (isRotated)
            {
                GameObject peice1 = Instantiate(devPiece, new Vector3(0.0f, y, 0.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f));
                GameObject peice2 = Instantiate(devPiece, new Vector3(xGap + 1, y, 0.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f));
                GameObject peice3 = Instantiate(devPiece, new Vector3(-(xGap + 1), y, 0.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f));
                peice1.tag = "pieceRot";
                peice2.tag = "pieceRot";
                peice3.tag = "pieceRot";
                peice1.name += i;
                peice2.name += i + 1;
                peice3.name += i + 2;
            }
            else
            {
                GameObject peice1 = Instantiate(devPiece, new Vector3(0.0f, y, 0.0f), Quaternion.identity);
                GameObject peice2 = Instantiate(devPiece, new Vector3(0.0f, y, xGap + 1), Quaternion.identity);
                GameObject peice3 = Instantiate(devPiece, new Vector3(0.0f, y, -(xGap + 1)), Quaternion.identity);
                peice1.name += i;
                peice2.name += i + 1;
                peice3.name += i + 2;
            }
            isRotated = !isRotated;
            y += yHeight + yGap;
        }
        getY = true;
    }
}
