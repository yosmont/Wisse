using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public PingController ping;
    [HideInInspector]
    public Dictionary<string, bool> inventory = new Dictionary<string, bool>();
    public bool isMoving = false;
    private GameObject spriteObject;
    private bool moveRight = true;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteObject = transform.Find("playerSprite").gameObject;
        spriteObject.GetComponent<Animator>().Play("Idle");
    }

    // Start is called before the first frame update
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        foreach (GameObject elem in GameObject.FindGameObjectsWithTag("CollectableItem"))
            inventory.Add(elem.name, false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 InputWorldPoint = Vector3.zero;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                if (Input.touches[0].phase == TouchPhase.Began) {
                    InputWorldPoint = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                }
            }
        } else {
            if (Input.GetMouseButtonDown(0)) {
                InputWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (InputWorldPoint != Vector3.zero) {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(InputWorldPoint.x, InputWorldPoint.y), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "PNJ") {
                hit.collider.GetComponent<APNJTalk>().Talk();
            } else if (hit.collider != null && hit.collider.tag == "CollectableItem") {
                inventory[hit.collider.name] = true;
                Destroy(hit.collider.gameObject);
            } else {
                InputWorldPoint.z = 0;
                agent.SetDestination(InputWorldPoint);
                ping.Move(agent.destination);
            }
        }
        Move();
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
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "PortalToLevel")
                hit.collider.GetComponent<PortalToLevel>().ChangeLevel();
            isMoving = false;
            spriteObject.GetComponent<Animator>().Play("Idle");
            ping.Stop();
        }
    }

    public void Stop()
    {
        ping.Stop();
        agent.SetDestination(new Vector3(transform.position.x, transform.position.y, 0));
        spriteObject.GetComponent<Animator>().Play("Idle");
    }
}