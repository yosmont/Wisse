﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public GameObject spriteObject;
    private bool isMoving = false;
    private bool moveRight = true;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer)
            UpdatePhone();
        else
            UpdatePC();
        Move();
    }

    void UpdatePC()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(dest.x, dest.y), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "PNJ") {
                hit.collider.GetComponent<APNJTalk>().Talk();
            } else {
                dest.z = 0;
                agent.SetDestination(dest);
            }
        }
    }

    void UpdatePhone()
    {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                Vector3 dest = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(new Vector2(dest.x, dest.y), Vector2.zero);
                if (hit.collider != null && hit.collider.tag == "PNJ") {
                    hit.collider.GetComponent<APNJTalk>().Talk();
                } else {
                    dest.z = 0;
                    agent.SetDestination(dest);
                }
            }
        }
    }

    void Move()
    {
        if (agent.velocity != Vector3.zero) {
            if (agent.velocity.x < 0 && !moveRight) {
                spriteObject.GetComponent<SpriteRenderer>().flipX = true;
                moveRight = true;
            } else if (agent.velocity.x > 0 && moveRight) {
                spriteObject.GetComponent<SpriteRenderer>().flipX = false;
                moveRight = false;
            }
            if (!isMoving) {
                isMoving = true;
                spriteObject.GetComponent<Animator>().Play("Move");
            }
        } else if (isMoving) {
            isMoving = false;
            spriteObject.GetComponent<Animator>().Play("Idle");
        }
    }
}