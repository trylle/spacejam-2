using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedTextUpdate : MonoBehaviour
{
    GameManager gameManager;
    float? diedTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOvered && !gameManager.win)
        {
            if (!diedTime.HasValue) diedTime = Time.time;

            GetComponent<CanvasGroup>().alpha = Mathf.Clamp01(Time.time - diedTime.Value);
        }
    }
}
