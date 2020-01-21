using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSingleton : MonoBehaviour
{
    public static ConfigSingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    public string sceneToLoad = "";
}
