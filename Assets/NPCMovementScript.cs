using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 randomDir = new Vector3(Mathf.Cos(angle),0, Mathf.Sin(angle));
        rb.velocity = randomDir * 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 randomDir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        rb.velocity = randomDir * 30;
    }
}
