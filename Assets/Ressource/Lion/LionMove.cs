using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMove : MonoBehaviour
{
    private Vector2 move;
    private Rigidbody2D lion;
    private Vector3 speed;
    private float moveSpeed = 5.0f;
    private int dirUp = -1;
    private Animator moveType;
    public Camera cam;
    public bool playing = true;

    void Start()
    {
        moveType = GetComponent<Animator>();
        lion = GetComponent<Rigidbody2D>();
        move = new Vector2(1, 0);
        speed = new Vector3(0, dirUp * moveSpeed, 0);
        lion.velocity = speed;
        moveType.Play("walk");
    }

    void Update()
    {
        if ((cam.WorldToViewportPoint(lion.position).y > 0.85 ||
            cam.WorldToViewportPoint(lion.position).y < 0.15))
        {
            dirUp *= -1;
            speed.y = dirUp * moveSpeed;
            lion.velocity = speed;
        }
        else if ((cam.WorldToViewportPoint(lion.position).x > 1 ||
        cam.WorldToViewportPoint(lion.position).x < 0))
            playing = false;
    }
}
