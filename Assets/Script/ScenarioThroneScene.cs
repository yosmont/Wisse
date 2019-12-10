using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioThroneScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("DialogueThroneScene").GetComponent<APNJTalk>().Talk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
