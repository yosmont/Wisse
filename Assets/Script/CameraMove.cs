using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector2Int noMoveSize = new Vector2Int(1,1);
    public Vector2Int levelOrigin = new Vector2Int(-15, 15);
    public Vector2Int levelLow = new Vector2Int(15, -15);
    public GameObject player;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = player.GetComponent<PlayerMove>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (transform.position.x < (player.transform.position.x - noMoveSize.x) && transform.position.x < player.transform.position.x && transform.position.x < levelLow.x)
            tmp.x += speed;
        else if (transform.position.x > (player.transform.position.x + noMoveSize.x) && transform.position.x > player.transform.position.x && transform.position.x > levelOrigin.x)
            tmp.x -= speed;
        if (transform.position.y < (player.transform.position.y - noMoveSize.y) && transform.position.y < player.transform.position.y && transform.position.y < levelOrigin.y)
            tmp.y += speed;
        else if (transform.position.y > (player.transform.position.y + noMoveSize.y) && transform.position.y > player.transform.position.y && transform.position.y > levelLow.y)
            tmp.y -= speed;
        transform.position = tmp;
    }
}
