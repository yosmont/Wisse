﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    //public GameObject player = null;
    //public SceneLoader _loader;
    /*public Transform playerTransform;
    public float playerStart = -4.3f;
    public float playerEnd = 4.3f;*/

    [Range(0f, 1f)]
    private float _progress = 0;

    Image _redBar;
    //bool moving = false;

    [ExecuteInEditMode]
    // Start is called before the first frame update
    void Start()
    {
        /*if (player == null)
        {
            player = GameObject.Find("Player");
            player.GetComponentInChildren<Animator>().Play("Idle");
        }

        playerTransform = GameObject.Find("playerSprite").GetComponent<Transform>();*/
        _redBar = GameObject.Find("LoadBar").GetComponent<Image>();
        Debug.Log($"[Load] - Should be loading {Config.Instance.sceneToLoad}");
    }

    // Update is called once per frame
    void Update()
    {
        _progress = Config.Instance.loadingProgress;
        _redBar.fillAmount = 1 - _progress;
        /*if (!moving && progress > 0.05 && progress < 0.95)
        {
            player.GetComponentInChildren<Animator>().Play("Move");
            moving = true;
        }
        if (progress == 1) {
            player.GetComponentInChildren<Animator>().Play("Idle");
            moving = false;
        }
        if (progress >= 0.07)
        {
            Vector2 tmp = playerTransform.position;
            tmp.x = playerStart + ((Mathf.Abs(playerStart) + Mathf.Abs(playerEnd)) * progress) - (1 - progress) + 0.25f;
            tmp.y = playerTransform.position.y;
            playerTransform.position = tmp;
        }*/
    }
}
