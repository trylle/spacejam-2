using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = transform.position;

        newPosition.x = target.position.x;

        newPosition.x = Mathf.Clamp(newPosition.x, -13, 100);

        transform.position = newPosition;
    }
}
