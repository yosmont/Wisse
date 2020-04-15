using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iolas : MonoBehaviour
{
    public float _speed = 5f;
    private Rigidbody2D _rb;
    private List<GameObject> _targetHead = new List<GameObject>();
    private Vector2 _startingPos;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _startingPos = _rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = _startingPos;
        if (_targetHead.Count > 0) {
            targetPos = _targetHead[0].transform.position;
        }
        _rb.position = Vector2.MoveTowards(_rb.position, targetPos, _speed * Time.deltaTime);
    }

    void SetNextTargetPos()
    {
    }

    public void AddTarget(GameObject obj)
    {
        if (!_targetHead.Find(x => x == obj))
            _targetHead.Add(obj);
    }

    public void RemoveTarget(GameObject obj)
    {
        if (_targetHead.Find(x => x == obj))
            _targetHead.Remove(obj);
    }
}
