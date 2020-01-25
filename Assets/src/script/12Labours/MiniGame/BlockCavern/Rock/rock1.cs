using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock1 : MonoBehaviour
{
//    [SerializeField]
    public Transform _rockPlace;
//    private Transform rockPlace;
    private Vector2 _initialPos;
    private Vector2 _mousePosition;
    private float _deltaX, _deltaY;
    public bool _locked;

    void Start()
    {
        _initialPos = transform.position;
    }

    private void OnMouseDown()
    {
        if (!_locked) {
            _deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            _deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    private void OnMouseDrag()
    {
        if (!_locked) {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(_mousePosition.x - _deltaX, _mousePosition.y - _deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - _rockPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - _rockPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(_rockPlace.position.x, _rockPlace.position.y);
            _locked = true;
        }
        else
        {
            transform.position = new Vector2(_initialPos.x, _initialPos.y);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0 && !_locked) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase) {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        _deltaX = touchPos.x - transform.position.x;
                        _deltaY = touchPos.y - transform.position.y;
                    }
                    break;
                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x - _rockPlace.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - _rockPlace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(_rockPlace.position.x, _rockPlace.position.y);
                        _locked = true;
                    }
                    else
                    {
                        transform.position = new Vector2(_initialPos.x, _initialPos.y);
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        transform.position = new Vector2(touchPos.x - _deltaX, touchPos.y - _deltaY);
                    }
                    break;
            }
        }
    }
}