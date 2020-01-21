using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingController : MonoBehaviour
{
    [HideInInspector]
    public bool isDisplay = false;
    private Image sprite  = null;
    private Vector3 dest;

    private void Awake()
    {
        sprite = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisplay) {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(dest);
            screenPos = new Vector3(screenPos.x, screenPos.y + 7, screenPos.z);
            transform.position = screenPos;
        }
    }

    public void Move(Vector3 worldPos)
    {
        if (!isDisplay) {
            isDisplay = true;
            sprite.enabled = true;
        }
        dest = worldPos;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(dest);
        screenPos = new Vector3(screenPos.x, screenPos.y + 7, screenPos.z);
        transform.position = screenPos;
        GetComponent<Animator>().Play("Ping");
    }

    public void Stop()
    {
        if (isDisplay) {
            isDisplay = false;
            sprite.enabled = false;
        }
    }
}
