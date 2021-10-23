using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float oxygenLevel = 1;
    public float oxygenDropRate = 1.0f / 60.0f;
    public bool gameOvered = false;
    public bool win = false;

    public string nextLevel = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOvered) return;

        oxygenLevel -= oxygenDropRate * Time.deltaTime;
        oxygenLevel = Mathf.Max(0, oxygenLevel);

        if (oxygenLevel <= 0 || Input.GetKey("r"))
            Restart();
    }

    public void NextLevel()
    {
        if (gameOvered)
            return;

        gameOvered = true;
        win = true;

        if (nextLevel != null)
            Invoke("NextScene", 1f);
    }

    public void Restart()
    {
        if (gameOvered) return;

        gameOvered = true;

        Invoke("ReloadScene", 1f);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
