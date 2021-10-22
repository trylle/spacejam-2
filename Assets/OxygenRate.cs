using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenRate : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager")?.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var scrollbar = GetComponent<Scrollbar>();

        if (scrollbar)
            scrollbar.size = 1 - gm.oxygenLevel;
    }
}
