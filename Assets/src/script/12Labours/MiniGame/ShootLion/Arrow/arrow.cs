﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
//using static System.Math;

public class arrow : MonoBehaviour
{
    private bool _isPressed;

    private Rigidbody2D _rb;
    private SpringJoint2D _sj;
    private Rigidbody2D _slingRb;
    public Camera _cam;

    public GameObject _bow;

    private float _releaseDelay;
    private float _maxDragDistance = 1.5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sj = GetComponent<SpringJoint2D>();
        _slingRb = _sj.connectedBody;

        _releaseDelay = 1 / (_sj.frequency * 4);
    }

    void Update()
    {
        if (_isPressed)
        {
            DragBall();
        }
        if (!((_cam.WorldToViewportPoint(_rb.position).x > 0 &&
            _cam.WorldToViewportPoint(_rb.position).x < 1) &&
            (_cam.WorldToViewportPoint(_rb.position).y < 1 &&
            _cam.WorldToViewportPoint(_rb.position).y > 0))) {
            _bow.transform.eulerAngles = new Vector3(0, 0, 180);
            transform.position = new Vector3((float)-7.7, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            _sj.enabled = true;
            _rb.isKinematic = false;
            _rb.bodyType = RigidbodyType2D.Static;
            _rb.GetComponent<BoxCollider2D>().size = new Vector2(6.57f, 10f);
            _rb.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
        }
    }

    private void DragBall()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, _slingRb.position);

        if (distance > _maxDragDistance) {
            Vector2 direction = (mousePosition - _slingRb.position).normalized;
            _rb.position = _slingRb.position + direction * _maxDragDistance;
        } else {
            _rb.position = mousePosition;
        }
        float o = mousePosition.x - (float)-7.7;
        float a = mousePosition.y - 0;
        double angle = 90 - Atan(o / a) * (180.0 / PI);
       if (mousePosition.y < 0)
            angle += 180;
        _rb.rotation = (float)angle + 180;
        _bow.transform.eulerAngles = new Vector3(0, 0, (float)angle);
    }

    private void OnMouseDown()
    {
        _isPressed = true;
        _rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        _isPressed = false;
        _rb.isKinematic = false;
        StartCoroutine(Release());
    }

    private IEnumerator Release() {
        yield return new WaitForSeconds(_releaseDelay);
        _sj.enabled = false;
        _rb.GetComponent<BoxCollider2D>().size = new Vector2(6f, 0.6f);
        _rb.GetComponent<BoxCollider2D>().offset = new Vector2(3f, 0f);
    }
}
