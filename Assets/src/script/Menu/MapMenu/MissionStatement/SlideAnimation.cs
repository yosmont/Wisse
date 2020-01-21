using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    public bool show = false;

    [Range(0f, 1f)]
    public float moveSpeed = 0.42f;

    public float hideAnchorX = -12f;
    public float showAnchorX = -4.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (show == true && transform.position.x < showAnchorX)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(p.x + moveSpeed, p.y, p.z);
        }
        if (show == false && transform.position.x > hideAnchorX)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(p.x - moveSpeed, p.y, p.z);
        }
    }
}
