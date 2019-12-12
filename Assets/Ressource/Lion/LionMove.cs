using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMove : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 15f;
    private Rigidbody2D lion;
    private Vector3 speed;
    private float moveSpeed = 150.0f;
    private int dirUp = -1;
    private Vector3 pos;
    private Animator moveType;
    public Camera cam;
    public StartMenu menu = null;

    void Start()
    {
        currentTime = startingTime;
        moveType = GetComponent<Animator>();
        lion = GetComponent<Rigidbody2D>();
        pos = new Vector3(7.5f, 2.6f, 0);
        speed = new Vector3(0, dirUp * moveSpeed * Time.deltaTime, 0);
        lion.velocity = speed;
        moveType.Play("walk");
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        lion.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (currentTime <= 0)
        {
            currentTime = startingTime;
            lion.position = pos;
        }

        if ((cam.WorldToViewportPoint(lion.position).y >= 0.85 ||
            cam.WorldToViewportPoint(lion.position).y <= 0.15))
        {
            dirUp *= -1;
            speed.y = dirUp * moveSpeed * Time.deltaTime;
            lion.velocity = speed;
        } else if ((cam.WorldToViewportPoint(lion.position).x - 0.07 >= 1 ||
            cam.WorldToViewportPoint(lion.position).x <= 0) ||
            (cam.WorldToViewportPoint(lion.position).y >= 1 ||
            cam.WorldToViewportPoint(lion.position).y <= 0))
        {
            menu.Win();
        }
    }
}
