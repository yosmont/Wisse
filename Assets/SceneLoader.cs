using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Config.Instance.loadingScene == 1)
        {
            Debug.Log("Requesting scene load");
            StartCoroutine(LoadOtherScene(Config.Instance.sceneToLoad));
            Config.Instance.loadingProgress = 0;
            Config.Instance.loadingScene = 2;
        }
    }

    IEnumerator LoadOtherScene(int idx)
    {
        AsyncOperation loader = SceneManager.LoadSceneAsync(idx);
        Debug.Log($"Loading scene : {idx}");

        while (loader.progress < 1)
        {
            Config.Instance.loadingProgress = loader.progress;
        }

        Config.Instance.loadingScene = 3;

        yield return new WaitForEndOfFrame();
    }
}
