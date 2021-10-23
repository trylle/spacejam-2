using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    Vector3 mousePos;
    Vector3 playerPos;
    public float Force = 5f;
    public ParticleSystem particles;
    public bool Enabled = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        particles.Stop();
    }

    public void StartExtinguisher()
    {
        enabled = true;
        particles.Play();
    }

    public void StopExtinguisher()
    {
        enabled = false;
        particles.Stop(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enabled)
        {
            playerPos = player.transform.position;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit)) return;
            Vector3 direction = (playerPos - hit.point);
            direction.y = 0;
            rb.velocity = direction.normalized * Force;
        }

    }
}
