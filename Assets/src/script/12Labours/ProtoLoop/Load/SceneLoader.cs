using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float coef = 0.1f;
    public string levelPath = "12Labours/Level/SalleDuTrone";

    // Start is called before the first frame update
    void Start()
    {
        Config.Instance.loadingProgress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Config.Instance.loadingProgress < 1)
            Config.Instance.loadingProgress += coef * Time.deltaTime;
        else
        {
            SceneManager.LoadScene("src/scene/" + this.levelPath);

        }
        /*
        if (Config.Instance.loadingScene == 1)
        {
            Debug.Log("Requesting scene load");
            StartCoroutine(LoadOtherScene(Config.Instance.sceneToLoad));
            Config.Instance.loadingProgress = 0;
            Config.Instance.loadingScene = 2;
        }
        */
    }

    IEnumerator LoadOtherScene(string sceneName)
    {
        AsyncOperation loader = SceneManager.LoadSceneAsync(sceneName);

        while (loader.progress < 1)
        {
            Config.Instance.loadingProgress = loader.progress;
        }

        Config.Instance.loadingScene = 3;

        yield return new WaitForEndOfFrame();
    }
}
