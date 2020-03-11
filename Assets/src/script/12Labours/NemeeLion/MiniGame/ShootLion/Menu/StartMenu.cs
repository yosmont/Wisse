using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string _levelPath;

    private bool _gameIsEnded = false;
    public GameObject _pauseMenuUI;
    [SerializeField] public Text _displayText = null;

    void Start()
    {
        //Screen.orientation = ScreenOrientation.Portrait;
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void Update()
    {
    }

    void Resume()
    {
        if (!_gameIsEnded)
        {
            Time.timeScale = 1f;
            _pauseMenuUI.SetActive(false);
        } else
        {
            //Screen.orientation = ScreenOrientation.LandscapeLeft;
            SceneManager.LoadScene("src/scene/" + _levelPath);
        }
    }

    public void End()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Win()
    {
        _pauseMenuUI.SetActive(true);
        _displayText.text = "Mes flèches lui rebondissent dessus, en plus il s'est enfui.\n\nIl va falloir trouver autre chose.";
        GetComponent<CountDownTimer>().enabled = false;
        _gameIsEnded = true;
    }
}
