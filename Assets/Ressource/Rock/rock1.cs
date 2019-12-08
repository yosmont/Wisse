using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock1 : MonoBehaviour
{
//    [SerializeField]
    public Transform rockPlace;
//    private Transform rockPlace;
    private Vector2 initialPos;
    private Vector2 mousePosition;
    private float deltaX, deltaY;
    public static bool locked;

    void Start()
    {
        initialPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (!locked) {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!locked) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - rockPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - rockPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(rockPlace.position.x, rockPlace.position.y);
//            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPos.x, initialPos.y);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && !locked) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase) {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - rockPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - rockPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(rockPlace.position.x, rockPlace.position.y);
//                        locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(initialPos.x, initialPos.y);
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    }
                    break;
            }
        }
    }
}