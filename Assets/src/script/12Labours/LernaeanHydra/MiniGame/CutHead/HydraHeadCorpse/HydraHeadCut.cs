using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHeadCut : MonoBehaviour
{
    public float _minHeight = -8.5f;
    public float _speed = 1f;
    public Sprite _burnSprite;
    private Rigidbody2D _rb;
    private SpawnHead _spawner;
    private bool _burnt = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spawner = GameObject.Find("Spawner").GetComponent<SpawnHead>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb.position.y > _minHeight)
            _rb.position -= new Vector2(0, _speed * Time.deltaTime);
        else {
            if (!_burnt)
                _spawner.AddHead();
            else
                _spawner.AddBurnHead();
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Torch") {
            GameObject.Find("Iolas").GetComponent<Iolas>().AddTarget(transform.GetChild(0).gameObject);
        } else if (collision.gameObject.name == "Iolas") {
            GameObject.Find("Iolas").GetComponent<Iolas>().RemoveTarget(transform.GetChild(0).gameObject);
            GetComponent<SpriteRenderer>().sprite = _burnSprite;
            _burnt = true;
        }
    }
}
