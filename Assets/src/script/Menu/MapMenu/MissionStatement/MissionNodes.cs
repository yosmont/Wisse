using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class MissionNodes : MonoBehaviour
{
    [Range(1, 12)]
    public int _nodeCount = 4;

    public string _prefix;
    public NodeControl[] _ctrlnodes;


    // Start is called before the first frame update
    void Start()
    {
        _ctrlnodes = GetComponentsInChildren<NodeControl>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (NodeControl node in _ctrlnodes)
        {
            node._open = node._number <= _nodeCount;
        }
    }
}
