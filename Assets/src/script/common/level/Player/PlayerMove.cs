using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public CursorController _cursor;
    [HideInInspector]
    public Dictionary<string, bool> _inventory = new Dictionary<string, bool>();
    public bool _isMoving = false;
    private GameObject _spriteObject;
    private bool _moveRight = true;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _spriteObject = transform.Find("playerSprite").gameObject;
        _spriteObject.GetComponent<Animator>().Play("Idle");
    }

    // Start is called before the first frame update
    void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        foreach (GameObject elem in GameObject.FindGameObjectsWithTag("CollectableItem"))
            _inventory.Add(elem.name, false);
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
                _inventory[hit.collider.name] = true;
                Destroy(hit.collider.gameObject);
            } else {
                InputWorldPoint.z = 0;
                _agent.SetDestination(InputWorldPoint);
                _cursor.Move(_agent.destination);
            }
        }
        Move();
    }

    void Move()
    {
        if (_agent.velocity != Vector3.zero) {
            if (_agent.velocity.x < 0 && !_moveRight) {
                _spriteObject.GetComponent<SpriteRenderer>().flipX = true;
                _moveRight = true;
            } else if (_agent.velocity.x > 0 && _moveRight) {
                _spriteObject.GetComponent<SpriteRenderer>().flipX = false;
                _moveRight = false;
            }
            if (!_isMoving) {
                _isMoving = true;
                _spriteObject.GetComponent<Animator>().Play("Move");
            }
        } else if (_isMoving) {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "PortalToLevel")
                hit.collider.GetComponent<PortalToLevel>().ChangeLevel();
            _isMoving = false;
            _spriteObject.GetComponent<Animator>().Play("Idle");
            _cursor.Stop();
        }
    }

    public void Stop()
    {
        _cursor.Stop();
        _agent.SetDestination(new Vector3(transform.position.x, transform.position.y, 0));
        _spriteObject.GetComponent<Animator>().Play("Idle");
    }
}