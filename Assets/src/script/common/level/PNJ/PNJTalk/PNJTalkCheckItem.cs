using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTalkCheckItem : APNJTalk
{
    public string _itemName;
    public string[] _ifOk = new string[2];

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
        int i = (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>()._inventory[_itemName]) ? 1 : 0;
        _dialManager.FollowDial(_ifOk[i], gameObject);
    }

    public override bool ContinueTalk()
    {
        throw new System.NotImplementedException();
    }
}
