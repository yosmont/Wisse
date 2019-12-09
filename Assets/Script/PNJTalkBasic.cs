using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJTalkBasic : APNJTalk
{
    [TextArea]
    public string talk;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Talk()
    {
        dialManager.GetComponent<DialogueManager>().SimpleDial(talk, gameObject);
    }

    public override bool continueTalk()
    {
        return false;
    }

    public override bool continueTalk(int choice)
    {
        throw new System.NotImplementedException();
    }
}
