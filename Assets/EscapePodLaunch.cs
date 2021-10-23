using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePodLaunch : MonoBehaviour
{
    float? launchTime;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (launchTime.HasValue)
        {
            float dt = Time.time - launchTime.Value;

            transform.position = startPosition + new Vector3(Mathf.Pow(dt, 2), 0, 0);
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "Player")
        {
            launchTime = Time.time;
            startPosition = transform.position;
            Object.Destroy(trigger.gameObject);
        }
    }
}
