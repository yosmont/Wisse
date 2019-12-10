using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public UnityEngine.UI.Image ping;
    [HideInInspector]
    public Dictionary<string, bool> inventory = new Dictionary<string, bool>();
    public bool isMoving = false;
    private GameObject spriteObject;
    private bool moveRight = true;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        GameObject[] collectableList = GameObject.FindGameObjectsWithTag("CollectableItem");
        foreach (GameObject elem in collectableList) {
            inventory.Add(elem.name, false);
        }
        spriteObject = transform.Find("playerSprite").gameObject;
        ping.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 InputWorldPoint = Vector3.negativeInfinity;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                if (Input.touches[0].phase == TouchPhase.Began)
                    InputWorldPoint = Camera.main.ScreenToWorldPoint(Input.touches[0].position); 
            }
        } else {
            if (Input.GetMouseButtonDown(0))
                InputWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (InputWorldPoint != Vector3.negativeInfinity) {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(InputWorldPoint.x, InputWorldPoint.y), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "PNJ") {
                hit.collider.GetComponent<APNJTalk>().Talk();
            } else if (hit.collider != null && hit.collider.tag == "CollectableItem") {
                inventory[hit.collider.name] = true;
                Destroy(hit.collider.gameObject);
            } else {
                InputWorldPoint.z = 0;
                agent.SetDestination(InputWorldPoint);
            }
        }
        Move();
    }

    void Move()
    {
        if (agent.velocity != Vector3.zero) {
            ping.transform.position = Camera.main.WorldToScreenPoint(agent.destination);
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
                ping.enabled = true;
                ping.GetComponent<Animator>().Play("Ping");
            }
        } else if (isMoving) {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "PortalToLevel")
                hit.collider.GetComponent<PortalToLevel>().ChangeLevel();
            isMoving = false;
            spriteObject.GetComponent<Animator>().Play("Idle");
            ping.enabled = false;
        }
    }

    public void Stop()
    {
        ping.enabled = false;
        agent.SetDestination(new Vector3(transform.position.x, transform.position.y, 0));
        spriteObject.GetComponent<Animator>().Play("Idle");
    }
}