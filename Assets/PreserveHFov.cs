using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveHFov : MonoBehaviour
{
    new Camera camera;
    float hfov;
    //
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        hfov = Camera.VerticalToHorizontalFieldOfView(camera.fieldOfView, 16.0f / 9.0f); // Game was developed for 16:9
    }

    // Update is called once per frame
    void Update()
    {
        camera.fieldOfView = Camera.HorizontalToVerticalFieldOfView(hfov, camera.aspect);
    }
}
