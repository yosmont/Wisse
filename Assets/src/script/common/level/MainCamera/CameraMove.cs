using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMove : MonoBehaviour
{
    public Vector2Int _noMoveSize = new Vector2Int(1,1);
    public GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (transform.position.x < (_player.transform.position.x - _noMoveSize.x) && transform.position.x < _player.transform.position.x)
            tmp.x = _player.transform.position.x - _noMoveSize.x;
        else if (transform.position.x > (_player.transform.position.x + _noMoveSize.x) && transform.position.x > _player.transform.position.x)
            tmp.x = _player.transform.position.x + _noMoveSize.x;
        if (transform.position.y < (_player.transform.position.y - _noMoveSize.y) && transform.position.y < _player.transform.position.y)
            tmp.y = _player.transform.position.y - _noMoveSize.y;
        else if (transform.position.y > (_player.transform.position.y + _noMoveSize.y) && transform.position.y > _player.transform.position.y)
            tmp.y = _player.transform.position.y + _noMoveSize.y;
        if (transform.position != tmp)
            transform.position = tmp;
    }
}
