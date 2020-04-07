using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHead : MonoBehaviour
{
    public float _maxHeight = -2.2f;
    public float _beginHeight = -8.5f;
    public float _speed = 0.5f;
    public List<float> _borderWidth = new List<float> { -7.2f, 7.2f };
    public GameObject _cutVersion;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.position = new Vector2(Random.Range(_borderWidth[0], _borderWidth[1]), _beginHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.position.y < _maxHeight) {
            _rb.position += new Vector2(0, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Blade")) {
            Instantiate(_cutVersion, _rb.position, new Quaternion());
            Destroy(gameObject);
        }
    }
}
