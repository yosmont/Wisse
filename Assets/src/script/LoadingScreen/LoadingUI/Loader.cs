using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private PercentBar _bar;
    private AsyncOperation _asyncLoad;

    private float _test;

    private void Awake()
    {
        _bar = GetComponentInChildren<PercentBar>();
    }

    private void Start()
    {
        _asyncLoad = SceneManager.LoadSceneAsync("src/scene/" + GameObject.Find("LoadingInfo").GetComponent<LoadingInfo>()._loadPath);
        _asyncLoad.allowSceneActivation = true;
        _bar.ChangePercent(_asyncLoad.progress);
    }

    private void Update()
    {
        _bar.ChangePercent(_asyncLoad.progress);
    }
}
