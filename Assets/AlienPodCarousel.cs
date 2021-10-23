using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPodCarousel : MonoBehaviour
{
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        const float scale = 1;

        gameObject.transform.position = startPosition + new Vector3(Mathf.Sin(time) * scale, 0, Mathf.Cos(time) * scale);
        gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.forward, new Vector3(-Mathf.Cos(time), 0, Mathf.Sin(time)));
    }
}
