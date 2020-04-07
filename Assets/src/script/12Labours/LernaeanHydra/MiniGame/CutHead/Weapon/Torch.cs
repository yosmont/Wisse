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

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        _circleColl = GetComponent<CircleCollider2D>();
        _circleColl.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
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
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                if (Input.touches[0].phase == TouchPhase.Began) {
                    BeginBurn();
                }
            }
        } else {
            if (Input.GetMouseButtonDown(0))
                BeginBurn();
        }
    }

    void BeginBurn()
    {
        SetPos();
        _circleColl.enabled = true;
        _timer = _lifeTime;
    }

    void StopBurn()
    {
        _circleColl.enabled = false;
    }

    void SetPos()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer)
            _rb.position = _cam.ScreenToWorldPoint(Input.touches[0].position);
        else
            _rb.position = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnDisable()
    {
        StopBurn();
    }
}
