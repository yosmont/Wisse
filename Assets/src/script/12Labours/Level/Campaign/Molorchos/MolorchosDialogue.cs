﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MolorchosDialogue : APNJTalk
{
    public Image _black;
    public Animator _anim;

    private bool _alreadyTalk = false;
    private int _currDialogue = 0;

    private string _afterTalk = "Bon courage pour ta mission !";

    private string[] _pnjName = {
        "",
        "Molorchos",
        "Héraclès",
        "Molorchos",
        "Héraclès",
        "Molorchos",
        "Héraclès",
        "Molorchos",
        "Héraclès"
    };

    private string[] _dialogue = {
        "",
        "Que faites-vous par ici ?",
        "On m’envoie tuer le lion de Némée.",
        "Qui donc serait assez fou pour vous confier une telle tâche.",
        "Surveilles tes paroles ! Il s’agit d'Eurysthée, je dois réaliser cette tâche afin d’expier mes tords.",
        "C’est une épreuve impossible qu’on t’a donné là. La bête a emporté mon fils, certains ont bien tenté de la tuer mais nulle lame ne peut transpercer sa peau. Tu ferais mieux de rentrer d’où tu viens.",
        "Je ne suis pas n’importe qui et mes armes ne sont pas si fragile. J’aurai la peau de cette bête et ce n’est pas toi qui m’arretera.",
        "Je n’en doute pas, laisse moi au moins t’offrir un lit pour la nuit et faire un sacrifice en ton honneur.",
        "Va pour le lit, mais ne fais pas de sacrifice : je ne suis pas un dieu. Attends un mois que je revienne avant de le faire. Comme ça, soit on honorera Zeus, soit tu honoreras la mort d’un héros."
    };

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void Talk()
    {
        if (_alreadyTalk)
            dialManager.GetComponent<DialogueManager>().SimpleDial(_afterTalk, gameObject, "Molorchos");
        else
            dialManager.GetComponent<DialogueManager>().SimpleDial(_dialogue[0], gameObject, "Molorchos");
    }

    public override bool continueTalk()
    {
        ++_currDialogue;
        if (!(_currDialogue < _dialogue.Length) && !_alreadyTalk)
        {
            _alreadyTalk = true;
            StartCoroutine(FadeIn());
            return false;
        } else if (_alreadyTalk)
        {
            return false;
        }
        dialManager.GetComponent<DialogueManager>().SimpleDial(_dialogue[_currDialogue], gameObject, _pnjName[_currDialogue]);
        return true;
    }

    public override bool continueTalk(int choice)
    {
        return false;
    }

    IEnumerator FadeIn()
    {
        _anim.SetBool("Fade", true);
        yield return new WaitUntil(() => _black.color.a == 1);
    }

    public bool GetAlreadyTalk()
    {
        return _alreadyTalk;
    }
}
