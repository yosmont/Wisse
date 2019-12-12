using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float coef = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Config.Instance.loadingProgress = 0f;
        Debug.Log($"You're supposed to load {Config.Instance.sceneToLoad}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Config.Instance.loadingProgress < 1)
            Config.Instance.loadingProgress += coef * Time.deltaTime;
        else
        {
            Debug.Log($"Loading completed, running scene {Config.Instance.sceneToLoad}");
            if (Config.Instance.sceneToLoad != "")
                SceneManager.LoadScene(Config.Instance.sceneToLoad);

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
        Debug.Log($"SCLD - Loading scene : {sceneName}");

        while (loader.progress < 1)
        {
            Config.Instance.loadingProgress = loader.progress;
        }

        Config.Instance.loadingScene = 3;

        yield return new WaitForEndOfFrame();
    }
}
