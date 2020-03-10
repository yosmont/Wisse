using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTalkQuiz : APNJTalk
{
    [TextArea]
    public string _talk;
    public string _goodOption;
    public string _badOption;

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
        _dialManager.SimpleDial(_talk, gameObject);
        _dialManager.SetQuizButton(_goodOption, _badOption);
    }

    public override bool ContinueTalk()
    {
        return false;
    }
}
