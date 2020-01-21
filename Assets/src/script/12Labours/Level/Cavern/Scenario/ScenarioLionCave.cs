using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioLionCave : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D heracles;
    private Vector3 pos;
    private bool hasTalked = false;
    private bool hasTalked2 = false;

    void Start()
    {
        player = GameObject.Find("player");
        heracles = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hasTalked = player.GetComponent<DialogueCave>().hasTalked;
        hasTalked2 = player.GetComponent<DialogueCave>().hasTalked2;
        pos = heracles.position;
        if (pos.x >= 5 && !hasTalked)
            player.GetComponent<APNJTalk>().Talk();
        if (pos.x >= 9 && pos.y <= 0 && !hasTalked2)
            player.GetComponent<APNJTalk>().Talk();
    }
}
