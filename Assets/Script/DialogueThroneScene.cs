using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueThroneScene : APNJTalk
{
    private int currDialogue = 0;
    private string[] PnjName =
    {
        "Héraclès",
        "Eurysthée",
        "Héraclès",
        "Eurysthée",
        "Héraclès",
        "Eurysthée",
        "Héraclès",
        "Eurysthée",
        "Héraclès",
        "Eurysthée",
        "Héraclès",
        "Héra",
        "Héraclès",
        "Eurysthée",
        "Héra"
    };
    private string[] str = {
        "Eurysthée !",
        "Heraclès? Pourquoi es-tu là, que me veux-tu cousin ?",
        "J’ai commis l’impossible ! Fait l’irréparable ! Que les dieux me pardonnent ! Que vais-je faire ?",
        "Reprends-toi donc et cesses tes jérémiades, expliques-moi plutôt ce qu’il s’est passé !",
        "Tout à coup, j’ai perdu le contrôle. Je n’arrivais plus à retenir mes coups. Mes enfants … Ma femme … Je les ai tués et j’ai brûlé leurs corps. Je suis allé à Delphes pour demander conseil à la Pythie et elle m’a redirigé vers toi.",
        "Vers moi ? Et que veux-tu que je fasse ? Ce sont tes crimes, je n’ai rien à voir avec ça. Va voir ailleurs.",
        "*comment lui dire que je dois me mettre à son service ? Cet être inférieur... C’est bien trop humiliant ! *",
        "Et bien quoi ? Pourquoi restes-tu là, sans bouger ?",
        "*Mais ce ne sont que 12 années et il s’agit là du seul moyen d’obtenir le pardon pour mon crime* Pour expier mes fautes, je dois me mettre à ton service pendant douze ans. Je ferai tous les travaux que tu me donneras.",
        "Des travaux... Ta vie m’appartient pendant 12 ans ? Laisse-moi quelques instants pour l’utiliser au mieux.",
        "…",
        "*murmurant à l’oreille d’Eurysthée* : demande-lui de tuer le lion de Némée",
        "Du coup ?",
        "Quelle impatience ! Mais j’ai trouvé. Va dans la forêt de Némée, tu y trouveras un lion qui dévore les troupeaux des bergers environnants. Tue-le et offre-moi sa peau pour preuve de ta réussite. Je te confierai ensuite ta prochaine tâche. *à condition bien sûr que tu survives à cette épreuve*",
        "(Héra) Aucune armes ne peut transpercer la peau de ce lion, Héraclès va mourir d’épuisement ou sous les coups du lion avant d’avoir pu faire la moindre chose. Ahahahaha"
    };

    void Start()
    {

    }

    void Update()
    {
        
    }
    public override void Talk()
    {
        dialManager.GetComponent<DialogueManager>().SimpleDial(str[0], gameObject, "Héracles");
    }

    public override bool continueTalk()
    {
        currDialogue++;
        dialManager.GetComponent<DialogueManager>().SimpleDial(str[currDialogue], gameObject, PnjName[currDialogue]);
        return currDialogue >= 15;
    }

    public override bool continueTalk(int choice)
    {
        return false;
    }
}
