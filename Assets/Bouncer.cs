using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    Rigidbody rb;
    bool grabbing = false;
    Vector3 lastVelocity;
    Vector3 hitNormal;
    public Vector3 initialVelocity = Vector3.zero;
    PlayerSounds playerSounds;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
        player = GameObject.Find("Player");
        playerSounds = player.GetComponent<PlayerSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbing)
        {
            float hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!new Plane(Vector3.up, Vector3.zero).Raycast(ray, out hit)) return;

            Vector3 delta = ray.GetPoint(hit) - rb.position;

            if (Input.GetMouseButton(0))
            {
                if (Vector3.Dot(delta, hitNormal) <= 0 || delta.magnitude <= 1e-3)
                    rb.transform.rotation = Quaternion.LookRotation(-hitNormal);
                else
                    rb.transform.rotation = Quaternion.LookRotation(-delta.normalized);
            }
            else
            {
                delta.y = 0;
                rb.velocity = delta;
                grabbing = false;
            }
        }
        else
        {
            if (rb.velocity.magnitude > 1e-3)
                rb.transform.rotation = Quaternion.LookRotation(rb.velocity.normalized);
        }
    }

    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        var normal = collision.GetContact(0).normal;

        playerSounds.Thud();

        if (collision.collider.tag == "Grabbable")
        {
            if (Input.GetMouseButton(0))
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                hitNormal = normal;
                grabbing = true;
                Debug.Log("grabbing");
            }
            else
            {
                rb.velocity = lastVelocity - 2 * Vector3.Dot(normal, lastVelocity) * normal;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
    }
}
