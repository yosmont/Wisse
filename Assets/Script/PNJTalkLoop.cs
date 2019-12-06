using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTalkLoop : APNJTalk
{
    public string[] talkArray;
    private int index = 0;

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
        dialManager.GetComponent<DialogueManager>().FollowDial(talkArray[index], gameObject);
        index = ((talkArray.Length - 1) > index) ? index + 1 : 0;
    }

    public override bool continueTalk()
    {
        throw new System.NotImplementedException();
    }

    public override bool continueTalk(int choice)
    {
        throw new System.NotImplementedException();
    }
}
