using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHeadOnly : MonoBehaviour
{
    public float _startSpeed = 200f;
    public float _lifeTime = 3f;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(Random.Range(_startSpeed * -1, _startSpeed), _startSpeed));
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
