using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string levelPath;

    public static bool GameIsPaused = true;
    public static bool GameIsEnded = false;
    public GameObject PauseMenuUI;
    [SerializeField] Text displayText = null;

    void Start()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
    }

    void Resume()
    {
        if (!GameIsEnded)
        {
            Time.timeScale = 1f;
            PauseMenuUI.SetActive(false);
            GameIsPaused = false;
        } else
        {
            SceneManager.LoadScene("src/scene/" + levelPath);
        }
    }

    public void End()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Win()
    {
        PauseMenuUI.SetActive(true);
        displayText.text = "Mes flèches lui rebondissent dessus, en plus il s'est enfui.\n\nIl va falloir trouver autre chose.";
        GetComponent<CountDownTimer>().enabled = false;
        GameIsPaused = true;
        GameIsEnded = true;
    }
}
