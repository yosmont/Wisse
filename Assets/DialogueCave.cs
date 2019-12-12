using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCave : APNJTalk
{
    private int currDialogue = 0;
    private string dialogue = "J'entends un courant d'air, j'ai l'impression qu'il y a une autre entrée. Il va falloir que je la ferme si je veux éviter que le lion s'enfuit.";
    private string postDialogue = "Je devrais pouvoir utiliser ces pierres.";
    public bool hasTalked = false;
    public bool hasTalked2 = false;
    void Start()
    {   
    }

    void Update()
    {        
    }

    public override void Talk()
    {
        if (!hasTalked)
        {
            dialManager.GetComponent<DialogueManager>().SimpleDial(dialogue, gameObject, "Héraclès");
            hasTalked = true;
        } else
        {
            dialManager.GetComponent<DialogueManager>().SimpleDial(postDialogue, gameObject, "Héraclès");
            hasTalked2 = true;
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

