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


    private void Awake()
    {
        _circleColl = GetComponent<CircleCollider2D>();
        _circleColl.enabled = false;
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer) {
            if (Input.touchCount > 0) {
                if (Input.touches[0].phase == TouchPhase.Began) {
                    StartCutting();
                } else if (Input.touches[0].phase == TouchPhase.Ended) {
                    StopCutting();
                }
            }
        } else {
            if (Input.GetMouseButtonDown(0))
                StartCutting();
            else if (Input.GetMouseButtonUp(0))
                StopCutting();
        }
        if (_isCutting)
            UpdateCut();
    }

    void StartCutting()
    {
        _isCutting = true;
        SetPos();
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
        SetPos();
        if (((_rb.position - _prevPos).magnitude * Time.deltaTime) > _minCuttingVelocity) {
            _circleColl.enabled = true;
        } else {
            _circleColl.enabled = false;
        }
        _prevPos = _rb.position;
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
        _isCutting = false;
        _circleColl.enabled = false;
        Destroy(_currentBladeTrail);
    }
}