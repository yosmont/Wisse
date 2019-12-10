using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerMove : MonoBehaviour
{
    public Vector3 destination;
    public float speed = 0.1f;

    public bool moving = false;

    GameObject playerModel;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.Find("playerSprite");
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && transform.position != destination)
        {
            playerModel.GetComponent<Animator>().Play("Move");
            Vector3 tmp = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = tmp;
        }
        if (moving && transform.position == destination)
        {
            playerModel.GetComponent<Animator>().Play("Idle");
            moving = false;
        }
    }
}
