using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iolas : MonoBehaviour
{
    private Rigidbody2D _rb;
    private List<GameObject> _targetHead;
    private Vector2 _startingPos;
    private Vector2 _targetPos;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startingPos = _rb.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetNextTargetPos()
    {
    }

    public void AddTarget(GameObject obj)
    {
    }
}
