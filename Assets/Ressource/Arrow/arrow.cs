using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;
//using static System.Math;

public class arrow : MonoBehaviour
{
    private bool IsPressed;

    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private Rigidbody2D slingRb;
    public GameObject bow;

    private float releaseDelay;
    private float maxDragDistance = 1.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        slingRb = sj.connectedBody;

        releaseDelay = 1 / (sj.frequency * 4);
    }

    void Update()
    {
        if (IsPressed)
        {
            DragBall();
        }
    }

    private void DragBall()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePosition, slingRb.position);

        if (distance > maxDragDistance) {
            Vector2 direction = (mousePosition - slingRb.position).normalized;
            rb.position = slingRb.position + direction * maxDragDistance;
        } else {
            rb.position = mousePosition;
        }
        float o = mousePosition.x - 0;
        float a = mousePosition.y - -3;
        double angle = 90 - Atan(o / a) * (180.0 / 3.141592653589793238463);
        rb.rotation = (float)angle;
        bow.transform.eulerAngles = new Vector3(0, 0, (float)angle + 180);
    }

    private void OnMouseDown()
    {
        IsPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        IsPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    private IEnumerator Release() {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
    }
}

