using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject _bladeTrailPrefab;
    public float _minCuttingVelocity = 0.001f;
    private Vector2 _prevPos;
    private GameObject _currentBladeTrail;
    private CircleCollider2D _circleColl;
    private bool _isCutting = false;
    private Camera _cam;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _circleColl = GetComponent<CircleCollider2D>();
        _circleColl.enabled = false;
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0)) {
            StopCutting();
        }
        if (_isCutting) {
            UpdateCut();
        }
    }

    void StartCutting()
    {
        _isCutting = true;
        _rb.position = _cam.ScreenToWorldPoint(Input.mousePosition);
        _prevPos = _rb.position;
        _currentBladeTrail = Instantiate(_bladeTrailPrefab, _rb.transform);
    }

    void StopCutting()
    {
        _isCutting = false;
        _circleColl.enabled = false;
        _currentBladeTrail.transform.SetParent(null);
        Destroy(_currentBladeTrail, 1f);
    }

    void UpdateCut()
    {
        _rb.position = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (((_rb.position - _prevPos).magnitude * Time.deltaTime) > _minCuttingVelocity) {
            _circleColl.enabled = true;
        } else {
            _circleColl.enabled = false;
        }
        _prevPos = _rb.position;
    }
}