using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMove : MonoBehaviour
{
    public Vector2Int noMoveSize = new Vector2Int(1,1);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (transform.position.x < (player.transform.position.x - noMoveSize.x) && transform.position.x < player.transform.position.x)
            tmp.x = player.transform.position.x - noMoveSize.x;
        else if (transform.position.x > (player.transform.position.x + noMoveSize.x) && transform.position.x > player.transform.position.x)
            tmp.x = player.transform.position.x + noMoveSize.x;
        if (transform.position.y < (player.transform.position.y - noMoveSize.y) && transform.position.y < player.transform.position.y)
            tmp.y = player.transform.position.y - noMoveSize.y;
        else if (transform.position.y > (player.transform.position.y + noMoveSize.y) && transform.position.y > player.transform.position.y)
            tmp.y = player.transform.position.y + noMoveSize.y;
        if (transform.position != tmp)
            transform.position = tmp;
    }
}
