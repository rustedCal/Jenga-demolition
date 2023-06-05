using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 worldPos;
    public LayerMask layer;
    void Update()
    {
        mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hitData, 1000, layer))
        {
            Debug.Log("hitting a block!!!");
            worldPos = hitData.point;
        }

        transform.position = worldPos;
    }
}