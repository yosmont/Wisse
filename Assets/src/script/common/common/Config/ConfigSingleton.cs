using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSingleton : MonoBehaviour
{
    private static ConfigSingleton _instance;

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            LoadOption();
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnApplicationQuit()
    {
        SaveOption();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
            SaveOption();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SaveOption();
    }

    void LoadOption()
    {
        /*volume = PlayerPrefs.GetFloat("volume", 1);
        AudioListener.volume = volume;*/
    }

    void SaveOption()
    {
        //PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }
}