﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public GameObject _blackImg;
    public GameObject _loadingSlider;
    public GameObject _loadingPercentText;

    private Image _black;
    private Animator _anim;
    private Slider _slider;
    private TMPro.TextMeshProUGUI _percentText;

    private delegate IEnumerator fadeIEnum();

    private Queue<string> _cmd = new Queue<string>();
    private Dictionary<string, Delegate> _inDic;
    private Dictionary<string, Delegate> _outDic;
    private string _levelPath;

    private void Awake()
    {
        _inDic = new Dictionary<string, Delegate> {
            { "in", new fadeIEnum(FadeIn) },
            { "inLevel", new fadeIEnum(FadeInLevel) }
        };
        _outDic = new Dictionary<string, Delegate> {
            { "out", new fadeIEnum(FadeOut) }
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        _black = _blackImg.GetComponent<Image>();
        _anim = _blackImg.GetComponent<Animator>();
        _slider = _loadingSlider.GetComponent<Slider>();
        _loadingSlider.SetActive(false);
        _percentText = _loadingPercentText.GetComponent<TMPro.TextMeshProUGUI>();
        _loadingPercentText.SetActive(false);
        _cmd.Enqueue("out");
    }

    // Update is called once per frame
    void Update()
    {   
        if (_cmd.Count != 0) {
            if (_outDic.ContainsKey(_cmd.Peek()) && _black.color.a == 1) {
                StartCoroutine((IEnumerator)_outDic[_cmd.Dequeue()].DynamicInvoke());
            } else if (_inDic.ContainsKey(_cmd.Peek()) && _black.color.a == 0) {
                StartCoroutine((IEnumerator)_inDic[_cmd.Dequeue()].DynamicInvoke());
            }
        }
    }

    public void StartFadeIn()
    {
        if (_black.color.a == 0)
            StartCoroutine(FadeIn());
        else if (_cmd.Count == 0 || _inDic.ContainsKey(_cmd.Peek()))
            _cmd.Enqueue("in");
    }

    public void StartFadeOut()
    {
        if (_black.color.a == 1)
            StartCoroutine(FadeOut());
        else if (_cmd.Count == 0 || _outDic.ContainsKey(_cmd.Peek()))
            _cmd.Enqueue("out");
    }

    public void StartFadeInLevel(string levelPath)
    {
        this._levelPath = levelPath;
        if (_black.color.a == 0)
            StartCoroutine(FadeInLevel());
        else if (_cmd.Count == 0 || _inDic.ContainsKey(_cmd.Peek()))
            _cmd.Enqueue("inLevel");
    }

    IEnumerator FadeIn()
    {
        _anim.SetBool("Sleeped", false);
        _anim.SetBool("Fade", true);
        yield return new WaitUntil(() => _black.color.a == 1);
    }

    IEnumerator FadeOut()
    {
        _anim.SetBool("Sleeped", true);
        _anim.SetBool("Fade", false);
        yield return new WaitUntil(() => _black.color.a == 0);
    }

    IEnumerator FadeInLevel()
    {
        _anim.SetBool("Sleeped", false);
        _anim.SetBool("Fade", true);
        yield return new WaitUntil(() => _black.color.a == 1);
        SceneManager.LoadScene("src/scene/" + _levelPath);
    }
}
