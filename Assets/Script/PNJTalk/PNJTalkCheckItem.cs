using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTalkCheckItem : APNJTalk
{
    public string itemName;
    public string[] ifOk = new string[2];

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
        int i = (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().inventory[itemName]) ? 1 : 0;
        dialManager.GetComponent<DialogueManager>().FollowDial(ifOk[i], gameObject);
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
