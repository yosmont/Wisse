using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MolorchosDialogue : APNJTalk
{
    public FadeController _fade;
    private bool _alreadyTalk = false;
    private int _currDialogue = 0;

    private string _afterTalk = "Bon courage pour ta mission !";

    private string[] _pnjName = {
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
        "Que faites-vous par ici ?",
        "On m’envoie tuer le lion de Némée afin d’expier mes tords.",
        "Qui donc serait assez fou pour vous confier une telle tâche.",
        "Surveilles tes paroles ! Tu parles d’un roi, Eurysthée.",
        "C’est une épreuve impossible qu’on t’a donnée là : nulle lame ne peut transpercer sa peau.",
        "Je ne suis pas n’importe qui et mes armes ne sont pas si fragile. J’aurai sa peau et rien ne m’arrêtera.",
        "Ton courage te perdra, mais laisse-moi au moins t’offrir un lit pour la nuit et faire un sacrifice en ton honneur.",
        "Merci pour le lit, mais ne fais pas de sacrifice : je ne suis pas un dieu."
    };

    public override void Talk()
    {
        if (_alreadyTalk)
            _dialManager.SimpleDial(_afterTalk, gameObject, "Molorchos");
        else
            _dialManager.SimpleDial(_dialogue[0], gameObject, "Molorchos");
    }

    public override bool ContinueTalk()
    {
        ++_currDialogue;
        if (!(_currDialogue < _dialogue.Length) && !_alreadyTalk) {
            _alreadyTalk = true;
            _fade.StartFadeIn();
            _fade.StartFadeOut();
            return false;
        } else if (_alreadyTalk) {
            return false;
        }
        _dialManager.SimpleDial(_dialogue[_currDialogue], gameObject, _pnjName[_currDialogue]);
        return true;
    }

    public bool GetAlreadyTalk()
    {
        return _alreadyTalk;
    }
}
