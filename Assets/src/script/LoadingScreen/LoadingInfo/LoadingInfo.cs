using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingInfo : MonoBehaviour
{
    private static LoadingInfo _instance;
    [HideInInspector]
    public string _loadPath;

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        } else {
            Destroy(this);
        }
    }

    void Init()
    {
    }

    public void LoadLevel(string path)
    {
        SceneManager.LoadScene("src/scene/LoadingScreen/LoadingScreen");
        _loadPath = "src/scene/" + path;
    }
}
