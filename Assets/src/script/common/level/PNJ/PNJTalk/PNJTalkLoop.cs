using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTalkLoop : APNJTalk
{
    public string[] _talkArray;
    private int _index = 0;

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
        _dialManager.FollowDial(_talkArray[_index], gameObject);
        _index = ((_talkArray.Length - 1) > _index) ? _index + 1 : 0;
    }

    public override bool ContinueTalk()
    {
        throw new System.NotImplementedException();
    }
}
