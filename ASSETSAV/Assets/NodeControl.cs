using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeControl : MonoBehaviour
{
    [Range(1, 12)]
    public int number = 1;
    public string displayNumber;
    public bool open = true;

    PolygonCollider2D zone;
    SpriteRenderer sp;
    Text txZone;

    // Start is called before the first frame update
    void Start()
    {
        zone = GetComponent<PolygonCollider2D>();
        txZone = GetComponentInChildren<Text>();
        sp = GetComponent<SpriteRenderer>();

        txZone.text = displayNumber;

        sp.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (open && Input.GetMouseButtonDown(0))
        {
            Vector3 wpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mpos;
            mpos.x = wpos.x;
            mpos.y = wpos.y;

            if (zone.bounds.Contains(mpos))
            {
                // Load the scene here !
                Debug.Log($"Clicked on chapter {number}");
            }
        }
        if (open == false)
        {
            sp.color = Color.red;
        } else
        {
            sp.color = Color.white;
        }
    }
}
