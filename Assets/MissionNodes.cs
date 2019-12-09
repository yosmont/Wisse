using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class MissionNodes : MonoBehaviour
{
    [Range(1, 12)]
    public int NodeCount = 4;

    public string prefix;
    public NodeControl[] ctrlnodes;


    // Start is called before the first frame update
    void Start()
    {
        ctrlnodes = GetComponentsInChildren<NodeControl>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (NodeControl node in ctrlnodes)
        {
            node.open = node.number <= NodeCount;
        }
    }
}
