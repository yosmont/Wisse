using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    public string levelPath;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene(levelPath);
            }
        }        
    }

    void OnClick()
    {
        SceneManager.LoadScene(levelPath);
    }
}
