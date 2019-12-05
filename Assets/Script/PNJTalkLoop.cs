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
        print(talkArray[index]);
        index = ((talkArray.Length - 1) > index) ? index + 1 : 0;
    }
}
