using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float oxygenLevel = 1;
    public float oxygenDropRate = 1.0f / 60.0f;
    bool gameOvered = false;

    public string nextLevel = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        oxygenLevel -= oxygenDropRate * Time.deltaTime;
        oxygenLevel = Mathf.Max(0, oxygenLevel);

        if (oxygenLevel <= 0)
            Restart();
    }

    public void NextLevel()
    {
        if (gameOvered || nextLevel == null) return;

        gameOvered = true;

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
