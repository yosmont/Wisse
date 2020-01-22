using System.Collections;
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
            dialManager.GetComponent<DialogueManager>().SimpleDial(_dialogue, gameObject, "Héraclès");
            _step = 1;
        } else if (_step != 2) {
            dialManager.GetComponent<DialogueManager>().SimpleDial(_postDialogue, gameObject, "Héraclès");
            _step = 2;
        }
    }

    public override bool continueTalk()
    {
        return false;
    }

    public override bool continueTalk(int choice)
    {
        return false;
    }
}

