using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public bool opening = false;
    public bool closing = false;
    public float startXPos = 0;
    public float endXPos = 1;
    public float openingSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            float dir = (endXPos - startXPos);
            float xPos = transform.localPosition.x + (endXPos - startXPos) * openingSpeed * Time.deltaTime;
            xPos = Mathf.Min(dir * xPos, dir * endXPos) / dir;
            Vector3 new_pos = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = new_pos;
        }
        else if (closing)
        {
            float dir = (endXPos - startXPos);
            float xPos = transform.localPosition.x - dir * openingSpeed * Time.deltaTime;
            xPos = Mathf.Max(dir * xPos, dir * startXPos) / dir;
            Vector3 new_pos = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = new_pos;
        }
    }
}
