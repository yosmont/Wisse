using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNJTalkBasic : APNJTalk
{
    [TextArea]
    public string _talk;

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
        _dialManager.GetComponent<DialogueManager>().SimpleDial(_talk, gameObject);
    }

    public override bool ContinueTalk()
    {
        return false;
    }

    public override bool ContinueTalk(int choice)
    {
        throw new System.NotImplementedException();
    }
}
