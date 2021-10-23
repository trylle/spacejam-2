using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    Vector3 mousePos;
    Vector3 playerPos;
    public float Force = 500f;
    public ParticleSystem particles;
    public bool operating = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        StopExtinguisher();
    }

    public void StartExtinguisher()
    {
        operating = true;
        particles.Play();
    }

    public void StopExtinguisher()
    {
        operating = false;
        particles.Stop();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) != operating)
        {
            if (Input.GetMouseButton(0))
                StartExtinguisher();
            else
                StopExtinguisher();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!operating) return;

        playerPos = player.transform.position;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out hit)) return;

        Vector3 direction = (playerPos - hit.point);

        direction.y = 0;
        rb.AddForce(direction.normalized * Force * Time.fixedDeltaTime);

        if (rb.velocity.magnitude > 1e-3)
            rb.transform.rotation = Quaternion.FromToRotation(Vector3.forward, -direction);
    }
}
