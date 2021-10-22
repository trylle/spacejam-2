using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    Rigidbody rb;
    bool grabbing = false;
    Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(1, 0, 1);
        rb.velocity *= 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;

        if (grabbing && !Input.GetMouseButton(0))
        {
            rb.velocity = new Vector3(1, 0, -1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var normal = collision.GetContact(0).normal;

        if (collision.collider.tag == "Grabbable")
        {
            if (Input.GetMouseButton(0))
            {
                rb.velocity = new Vector3(0, 0, 0);
                grabbing = true;
            }
            else
            {
                rb.velocity = lastVelocity - 2 * Vector3.Dot(normal, lastVelocity) * normal;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        grabbing = false;
    }
}
