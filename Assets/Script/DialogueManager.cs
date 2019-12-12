﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject player;
    public Vector2 followShift = new Vector2(125, -100);
    public float followLifeTime = 2;
    private float followLifeTimer;
    private GameObject dialBox;
    private GameObject dialFollowBox;
    private GameObject currentPNJ = null;
    private GameObject currentImportantPNJ = null;
    private TextMeshProUGUI currentDialogue = null;

    private void Awake()
    {
        dialBox = transform.Find("DialogueBox").gameObject;
        dialFollowBox = transform.Find("DialogueFollowBox").gameObject;
        if (!player)
            transform.Find("ping").gameObject.SetActive(false);
        foreach (Transform child in dialBox.transform)
            child.gameObject.SetActive(false);
        dialBox.SetActive(false);
        dialFollowBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPNJ) {
            Vector3 wantedPos = Camera.main.WorldToScreenPoint(currentPNJ.transform.position);
            wantedPos.x -= followShift.x;
            wantedPos.y -= followShift.y;
            dialFollowBox.transform.position = wantedPos;
            followLifeTimer -= Time.deltaTime;
            if (followLifeTimer <= 0) {
                currentPNJ = null;
                dialFollowBox.SetActive(false);
            }
        }
        if (currentImportantPNJ) {
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)) {
                ++currentDialogue.pageToDisplay;
                if (currentDialogue.pageToDisplay > currentDialogue.textInfo.pageCount) {
                    if (!currentImportantPNJ.GetComponent<APNJTalk>().continueTalk()) {
                        if (player)
                            player.GetComponent<PlayerMove>().enabled = true;
                        dialBox.SetActive(false);
                        currentDialogue = null;
                        currentImportantPNJ = null;
                    }
                }
            }
        }
    }

    public void SimpleDial(string dial, GameObject PNJ, string talkerName)
    {
        currentImportantPNJ = PNJ;
        if (player) {
            player.GetComponent<PlayerMove>().Stop();
            player.GetComponent<PlayerMove>().enabled = false;
        }
        dialBox.SetActive(true);
        foreach (Transform child in dialBox.transform)
            child.gameObject.SetActive(false);
        GameObject tmp = dialBox.transform.Find("DialBasic").gameObject;
        tmp.SetActive(true);
        tmp.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = talkerName + ":";
        currentDialogue = tmp.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>();
        currentDialogue.text = dial;
        currentDialogue.pageToDisplay = 1;
    }

    public void SimpleDial(string dial, GameObject PNJ)
    {
        SimpleDial(dial, PNJ, PNJ.name);
    }
    
    public void SimpleDial(string dial, GameObject PNJ, GameObject talker)
    {
        SimpleDial(dial, PNJ, talker.name);
    }

    public void ChoiceDial(string dial, string[] choice, GameObject PNJ)
    {
    }

    public void FollowDial(string dial, GameObject PNJ)
    {
        currentPNJ = PNJ;
        followLifeTimer = followLifeTime;
        dialFollowBox.SetActive(true);
        dialFollowBox.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>().text = dial;
        Vector3 wantedPos = Camera.main.WorldToScreenPoint(PNJ.transform.position);
        wantedPos.x -= followShift.x;
        wantedPos.y -= followShift.y;
        dialFollowBox.transform.position = wantedPos;
    }
}
