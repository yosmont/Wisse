using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioForest2 : MonoBehaviour
{
    private Animator moveType;
    private GameObject Lion;
    private GameObject Player;
    private Rigidbody2D lion;
    private Vector3 speed;

    void Start()
    {
        Lion = GameObject.Find("lion");
        Player = GameObject.Find("player");
        Player.GetComponent<PlayerMove>().enabled = false;
        moveType = Lion.GetComponent<Animator>();
        lion = Lion.GetComponent<Rigidbody2D>();
        speed = new Vector3(95f * Time.deltaTime, 150f * Time.deltaTime, 0);
        lion.velocity = speed;
        moveType.Play("walk");
        StartCoroutine(MoveLion());
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(lion.position).y > 1 &&
        Camera.main.WorldToViewportPoint(lion.position).x > 1) {
            Player.GetComponent<PlayerMove>().enabled = true;
            Lion.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator MoveLion()
    {
        yield return new WaitUntil(() => (Camera.main.WorldToViewportPoint(lion.position).y > 1 &&
        Camera.main.WorldToViewportPoint(lion.position).x - 0.07 >= 1));
    }
}
