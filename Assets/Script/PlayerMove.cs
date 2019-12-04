using System.Collections;
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
            Vector3 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tmp.z = 0;
            agent.SetDestination(tmp);
        }
    }

    void UpdatePhone()
    {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary) {
                Vector3 tmp = Camera.main.ScreenToWorldPoint(touch.position);
                tmp.z = 0;
                agent.SetDestination(tmp);
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