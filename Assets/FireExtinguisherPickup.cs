using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisherPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            trigger.GetComponent<Bouncer>().enabled = false;
            trigger.GetComponent<FireExtinguisher>().enabled = true;

            Destroy(gameObject);
        }
    }
}
