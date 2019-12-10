using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
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
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
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
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameIsEnded = true;
    }
}
