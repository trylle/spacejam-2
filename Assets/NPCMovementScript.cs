using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        /*
        int angle = Random.Range(0, 360);
        decimal angleDec = new decimal(angle);
        double angleD = (double)angleDec;
        float angleF = ToSingle()
        rb.AddForce(System.Math.Sin(angleD), 0, System.Math.Cos(angleD));
        */

        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 randomDir = new Vector3(Mathf.Cos(angle),0, Mathf.Sin(angle));
        rb.velocity = randomDir * 40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
