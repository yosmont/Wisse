using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJTalkBasic : APNJTalk
{
    public string talk;
    public Image DialogueBox;

    // Start is called before the first frame update
    void Start()
    {
        DialogueBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Talk()
    {
        DialogueBox.enabled = true;
        DialogueBox.GetComponentInChildren<Text>().text = talk;
    }
}
