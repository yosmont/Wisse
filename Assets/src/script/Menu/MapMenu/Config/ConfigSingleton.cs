using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSingleton : MonoBehaviour
{
    private static ConfigSingleton _instance;
    public string _sceneToLoad;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            // Run the init functions here
        }
        else
            Destroy(gameObject);
    }

    void OnApplicationQuit()
    {
        // Application iz ded

    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Back to app
    }

    void OnApplicationPause(bool pauseStatus)
    {
        // App iz gone
    }
}
