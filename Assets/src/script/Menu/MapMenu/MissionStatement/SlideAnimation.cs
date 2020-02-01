using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    public bool _show = false;

    [Range(0f, 1f)]
    public float _moveSpeed = 0.2f;

    public float _hideAnchorX = -10f;
    public float _showAnchorX = -4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_show == true && transform.position.x < _showAnchorX)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(p.x + _moveSpeed, p.y, p.z);
        }
        if (_show == false && transform.position.x > _hideAnchorX)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(p.x - _moveSpeed, p.y, p.z);
        }
    }
}
