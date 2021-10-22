using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 startVelocity = Vector3.zero;
    public bool randomVelocity = false;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        if (randomVelocity)
        {
            float angle = Random.Range(0f, 2f * Mathf.PI);
            Vector3 randomDir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
            rb.velocity = randomDir * 3;
        }
        else
            rb.velocity = startVelocity;

        lastVelocity = rb.velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Random direction
        /*
        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 randomDir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        rb.velocity = randomDir * 30;
        */

        // Reflection direction

        var normal = collision.GetContact(0).normal;

        if (collision.collider.tag == "Grabbable")
        {
            rb.velocity = lastVelocity - 2 * Vector3.Dot(normal, lastVelocity) * normal;
        }
    }
}
