using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    Rigidbody rb;
    bool grabbing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(10, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall" && Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(0, 0, 0);
            grabbing = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {

    }
}
