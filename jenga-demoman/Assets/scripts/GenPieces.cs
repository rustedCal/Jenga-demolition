using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPieces : MonoBehaviour
{
    public GameObject devPiece;
    public float startY = 0.5f;
    public float yGap = 0.1f;
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
        int y;
        for (int i = 0; i < layers; i++)
        {
            GameObject peice = Instantiate(devPiece, new Vector3(0.0f,startY))
        }
    }
}
