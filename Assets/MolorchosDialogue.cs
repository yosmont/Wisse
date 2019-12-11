using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MolorchosDialogue : APNJTalk
{
    public Image black;
    public Animator anim;

    public bool alreadyTalk = false;
    private int currDialogue = 0;

    private string afterTalk = "Bonne courage pour ta mission !";

    private string[] pnjName =
    {
        "Molorchos",
        "Héraclès",
        "Molorchos",
        "Héraclès",
        "Molorchos",
        "Héraclès",
        "Molorchos",
        "Héraclès"
    };

    private string[] dialogue =
    {
        "Que faites-vous par ici ?",
        "On m’envoit tuer le lion de Némée.",
        "Qui donc serait assez fou pour vous confier tel tâche.",
        "Surveille tes parôles ! Il s’agit de Eurysthée, je dois réaliser cette tâche afin d’expier mes tords.",
        "C’est une épreuve impossible qu’on t’a donné là. La bête à emporté mon fils, certains ont bien tenté de la tuer mais nulle lame ne peut transpercer sa peau. Tu ferais mieux de rentrer d’où tu viens.",
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
        if (alreadyTalk)
            dialManager.GetComponent<DialogueManager>().SimpleDial(afterTalk, gameObject, "Molorchos");
        else
            dialManager.GetComponent<DialogueManager>().SimpleDial(dialogue[0], gameObject, "Molorchos");
    }

    public override bool continueTalk()
    {
        ++currDialogue;
        if (!(currDialogue < dialogue.Length) && !alreadyTalk)
        {
            alreadyTalk = true;
            StartCoroutine(FadeIn());
            return false;
        } else if (alreadyTalk)
        {
            return false;
        }
        dialManager.GetComponent<DialogueManager>().SimpleDial(dialogue[currDialogue], gameObject, pnjName[currDialogue]);
        return true;
    }

    public override bool continueTalk(int choice)
    {
        return false;
    }

    IEnumerator FadeIn()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
    }
}
