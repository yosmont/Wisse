using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public float _lifeTime = 0.5f;
    private float _timer = 0f;
    private CircleCollider2D _circleColl;
    private Rigidbody2D _rb;
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        _circleColl = GetComponent<CircleCollider2D>();
        _circleColl.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_circleColl.isActiveAndEnabled) {
            if (_timer <= 0)
                StopBurn();
            else
                _timer -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
            BeginBurn();
    }

    void BeginBurn()
    {
        _rb.position = _cam.ScreenToWorldPoint(Input.mousePosition);
        _circleColl.enabled = true;
        _timer = _lifeTime;
    }

    void StopBurn()
    {
        _circleColl.enabled = false;
    }

    private void OnDisable()
    {
        StopBurn();
    }
}
