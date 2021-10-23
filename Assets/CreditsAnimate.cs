using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAnimate : MonoBehaviour
{
    GameManager gameManager;
    float? winTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.win)
        {
            if (!winTime.HasValue) winTime = Time.time;

            GetComponent<CanvasGroup>().alpha = Mathf.Clamp01(Time.time - winTime.Value);
        }
    }
}
