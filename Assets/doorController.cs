using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    public openDoor door1;
    public openDoor door2;

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            door1.opening = true;
            door2.opening = true;
        }
    }
    void onTriggerExit(Collider trigger)
    {
        Debug.Log(trigger);
        if (trigger.tag == "Player")
        {
            door1.opening = false;
            door2.opening = false;
        }
    }
}
