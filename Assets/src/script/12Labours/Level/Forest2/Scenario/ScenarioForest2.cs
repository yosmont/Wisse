using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioForest2 : MonoBehaviour
{
    private Animator _moveType;
    private GameObject _lion;
    private GameObject _player;
    private Rigidbody2D _lionRB;
    private Vector3 _speed;

    private void Awake()
    {
        _lion = GameObject.Find("lion");
        _player = GameObject.Find("player");
        _moveType = _lion.GetComponent<Animator>();
        _lionRB = _lion.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _speed = new Vector3(95f * Time.deltaTime, 150f * Time.deltaTime, 0);
        _lionRB.velocity = _speed;
        _moveType.Play("walk");
        StartCoroutine(MoveLion());
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.WorldToViewportPoint(_lionRB.position).y > 1 &&
        Camera.main.WorldToViewportPoint(_lionRB.position).x > 1) {
            _lion.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator MoveLion()
    {
        yield return new WaitUntil(() => (Camera.main.WorldToViewportPoint(_lionRB.position).y > 1 &&
        Camera.main.WorldToViewportPoint(_lionRB.position).x - 0.07 >= 1));
    }
}
