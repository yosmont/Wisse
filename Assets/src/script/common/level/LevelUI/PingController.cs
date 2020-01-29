using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingController : MonoBehaviour
{
    private bool _isDisplay = false;
    private Image _sprite  = null;
    private Vector3 _dest;

    private void Awake()
    {
        _sprite = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDisplay) {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(_dest);
            screenPos = new Vector3(screenPos.x, screenPos.y + 7, screenPos.z);
            transform.position = screenPos;
        }
    }

    public void Move(Vector3 worldPos)
    {
        if (!_isDisplay) {
            _isDisplay = true;
            _sprite.enabled = true;
        }
        _dest = worldPos;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(_dest);
        screenPos = new Vector3(screenPos.x, screenPos.y + 7, screenPos.z);
        transform.position = screenPos;
        GetComponent<Animator>().Play("Ping");
    }

    public void Stop()
    {
        if (_isDisplay) {
            _isDisplay = false;
            _sprite.enabled = false;
        }
    }
}
