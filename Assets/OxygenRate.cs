using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenRate : MonoBehaviour
{
    public float startOxygen = 1;
    public float oxygenDropRate = 1.0f / 60.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startOxygen -= oxygenDropRate * Time.deltaTime;
        startOxygen = Mathf.Max(0, startOxygen);

        var scrollbar = GetComponent<Scrollbar>();

        if (scrollbar)
            scrollbar.size = 1 - startOxygen;

        if (startOxygen <= 0)
        {
            // TODO: Game over
        }
    }
}
