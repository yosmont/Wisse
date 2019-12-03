using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.125F;
    private Vector2Int moveTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.Lumin || Application.platform == RuntimePlatform.IPhonePlayer)
            UpdatePhone();
        else
            UpdatePC();
        Move();
    }

    void UpdatePC()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 tmp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveTo.x = (int)tmp.x;
            moveTo.y = (int)tmp.y;
        }
    }

    void UpdatePhone()
    {
        foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Began) {
                Vector2 tmp = Camera.main.ScreenToWorldPoint(touch.position);
                moveTo.x = (int)tmp.x;
                moveTo.y = (int)tmp.y;
            }
        }
    }

    void Move()
    {
        Vector2 tmp = new Vector2(transform.position.x, transform.position.y);
        if (transform.position.x < moveTo.x)
            tmp.x += speed;
        else if (transform.position.x > moveTo.x)
            tmp.x -= speed;
        if (transform.position.y < moveTo.y)
            tmp.y += speed;
        else if (transform.position.y > moveTo.y)
            tmp.y -= speed;
        transform.position = tmp;
    }
}