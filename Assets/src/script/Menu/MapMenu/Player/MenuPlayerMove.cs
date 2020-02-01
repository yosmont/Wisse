using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerMove : MonoBehaviour
{
    public Vector3 _destination;
    public float _speed = 5.0f;

    public bool _moving = false;

    private GameObject _playerModel;

    // Start is called before the first frame update
    void Start()
    {
        _playerModel = GameObject.Find("playerSprite");
    }

    // Update is called once per frame
    void Update()
    {
        if (_moving && transform.position != _destination)
        {
            _playerModel.GetComponent<Animator>().Play("Move");
            Vector3 tmp = Vector3.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);
            transform.position = tmp;
        }
        if (_moving && transform.position == _destination)
        {
            _playerModel.GetComponent<Animator>().Play("Idle");
            _moving = false;
        }
    }
}
