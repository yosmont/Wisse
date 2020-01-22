using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenarioThroneScene : MonoBehaviour
{
    public string levelPath;

    private Vector3 speed;
    private Rigidbody2D heracles;
    private Animator moveType;
    public Camera cam;

    private bool isTalking = true;
    private int second = 0;

    public Image black;
    public Animator anim;

    void Start()
    {
        GameObject.Find("Héraclès").GetComponent<APNJTalk>().Talk();
        speed = new Vector3(-1.5f, -1, 0);
        heracles = GameObject.Find("Héraclès").GetComponent<Rigidbody2D>();
        moveType = GameObject.Find("Héraclès").GetComponent<Animator>();
    }

    void Update()
    {
        isTalking = GameObject.Find("Héraclès").GetComponent<DialogueThroneScene>().isTalking;
        if (!isTalking && second == 0)
        {
            second = 1;
            heracles.velocity = speed;
            moveType.Play("Move");
            GameObject.Find("Héraclès").GetComponent<SpriteRenderer>().flipX = true;
        } else if (second == 1 && ((cam.WorldToViewportPoint(heracles.position).x - 0.07 >= 1 ||
               cam.WorldToViewportPoint(heracles.position).x + 0.07 <= 0) ||
               (cam.WorldToViewportPoint(heracles.position).y + 0.07 >= 1 ||
               cam.WorldToViewportPoint(heracles.position).y  + 0.07 <= 0)))
        {
            second = 3;
            GameObject.Find("Héraclès").GetComponent<APNJTalk>().Talk();
        } else if (isTalking && second == 3)
            StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a == 1);
        SceneManager.LoadScene("src/scene/" + levelPath);
    }
}
