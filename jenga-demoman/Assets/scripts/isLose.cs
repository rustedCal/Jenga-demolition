using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isLose : MonoBehaviour
{
    public MouseInteract mouse;
    public placeBlock place;
    public GameObject failScreen;
    public bool isFail = false;
    public int blockCount = 0;
    public bool triggerPlace = false;

    // Update is called once per frame
    void Update()
    {
        if (blockCount > 1)
        {
            isFail = true;
            mouse.enabled = false;
            place.enabled = false;
            failScreen.SetActive(true);
        }
    }
    //if a obj enters, add 1 to count. if obj exit, delet obj and sub 1 from count. if count  > 1, flag a fail bool
    private void OnTriggerEnter(Collider other)
    {
        blockCount++;
    }
    private void OnTriggerExit(Collider other)
    {
        blockCount--;
        Destroy(other.gameObject);
        if (!isFail)
        {
            triggerPlace = true;
            Debug.Log("triggering place bool");
        }
    }

}
