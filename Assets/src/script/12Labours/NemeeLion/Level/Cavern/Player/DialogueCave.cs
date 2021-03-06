﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCave : APNJTalk
{
    private string _dialogue = "J'entends un courant d'air, j'ai l'impression qu'il y a une autre entrée. Il va falloir que je la ferme si je veux éviter que le lion s'enfuit.";
    private string _postDialogue = "Je devrais pouvoir utiliser ces pierres pour boucher l'entrée.";
    private int _step = 0;

    void Start()
    {   
    }

    void Update()
    {        
    }

    public int GetStep()
    {
        return _step;
    }

    public override void Talk()
    {
        if (_step == 0) {
            _dialManager.FollowDial(_dialogue, gameObject);
            _step = 1;
        } else if (_step != 2) {
            _dialManager.FollowDial(_postDialogue, gameObject); 
            _step = 2;
        }
    }

    public override bool ContinueTalk()
    {
        return false;
    }
}

