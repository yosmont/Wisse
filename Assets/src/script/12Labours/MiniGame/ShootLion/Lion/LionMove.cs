using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMove : MonoBehaviour
{
    private float _currentTime = 0f;
    private float _startingTime = 15f;

    private Rigidbody2D _lion;
    private Vector3 _speed;
    private float _moveSpeed = 150.0f;
    private int _dirUp = -1;
    private Vector3 _pos;

    private Animator _moveType;
    private bool _gameEnded = false;
    public Camera _cam;
    public StartMenu _menu = null;

    void Start()
    {
        _currentTime = Time.deltaTime;
        _currentTime = _startingTime;
        _moveType = GetComponent<Animator>();
        _lion = GetComponent<Rigidbody2D>();
        _pos = new Vector3(7.5f, -3.7f, 0);
        _speed = new Vector3(0, _dirUp * _moveSpeed * Time.deltaTime, 0);
        _lion.velocity = _speed;
        _moveType.Play("walk");
    }

    void Update()
    {
        _currentTime -= 1 * Time.deltaTime;
        _lion.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (_currentTime <= 0 && !_gameEnded)
        {
            _currentTime = _startingTime;
            _lion.position = _pos;
        }

        if (_cam.WorldToViewportPoint(_lion.position).y >= 0.85)
        {
            _dirUp = -1;
            _speed.y = _dirUp * _moveSpeed * Time.deltaTime;
            _lion.velocity = _speed;
        } else if (_cam.WorldToViewportPoint(_lion.position).y <= 0.15)
        {
            _dirUp = 1;
            _speed.y = _dirUp * _moveSpeed * Time.deltaTime;
            _lion.velocity = _speed;
        } else if ((_cam.WorldToViewportPoint(_lion.position).x - 0.07 >= 1 ||
          _cam.WorldToViewportPoint(_lion.position).x <= 0) ||
          (_cam.WorldToViewportPoint(_lion.position).y >= 1 ||
          _cam.WorldToViewportPoint(_lion.position).y <= 0))
        {
            _gameEnded = true;
            _menu.Win();
        }
    }
}
