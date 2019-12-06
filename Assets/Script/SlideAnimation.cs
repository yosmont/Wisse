using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{
    public bool show = false;

    [Range(0f, 1f)]
    public float displacement = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (show == true && transform.position.x > 4.2)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(p.x - displacement, p.y, p.z);
        }
        if (show == false && transform.position.x < 12)
        {
            Vector3 p = transform.position;
            transform.position = new Vector3(p.x + displacement, p.y, p.z);
        }
    }
}
