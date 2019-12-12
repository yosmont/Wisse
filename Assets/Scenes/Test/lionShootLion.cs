using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lionShootLion : MonoBehaviour
{
    public int dir;
    private int[] pos = {-4, 4, 10};
    private Vector3[] mv = {new Vector3(0, -0.1F, 0), new Vector3(0, 0.1F, 0), new Vector3(0.1F, 0, 0)};

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().Play("walk");
        dir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == 2 && (int)transform.position.x == pos[dir])
            Debug.Log("hey");
        else if ((int)transform.position.y != pos[dir])
            transform.position = transform.position + mv[dir];
        else
            dir = (dir == 0) ? 1 : 0;
    }
}
