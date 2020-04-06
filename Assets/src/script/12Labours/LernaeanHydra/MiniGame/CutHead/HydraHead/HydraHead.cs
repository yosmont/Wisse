using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHead : MonoBehaviour
{
    public float _maxHeight = -2.2f;
    public float _beginHeight = -8.5f;
    public List<float> _borderWidth = new List<float> { -7.2f, 7.2f };
    public List<float> _sizeDif = new List<float> { 0.45f, -1f, 0f, 1.61f };
    public List<GameObject> _cutVersion;
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
            _rb.position += new Vector2(0, 0.5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) {
            Instantiate(_cutVersion[0], new Vector3(_rb.position.x + _sizeDif[0], _rb.position.y + _sizeDif[1], 0), new Quaternion());
            Instantiate(_cutVersion[1], new Vector3(_rb.position.x + _sizeDif[2], _rb.position.y + _sizeDif[3], 0), new Quaternion());
            Destroy(this.gameObject);
        }
    }
}
