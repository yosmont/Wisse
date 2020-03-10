using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueThroneScene : APNJTalk
{
    private int _currDialogue = 0;
    private bool _isTalking = true;

    private string[] _pnjName = {
        "Eurysthée",
        "Héraclès",
        "Eurysthée",
        "Héraclès",
        "Eurysthée",
        "Héra",
        "Eurysthée",
    };

    private string[] _str = {
        "Heraclès ? Que fais-tu là ? Que me veux-tu cousin ?",
        "Mes enfants … Ma femme … Je les ai tués et j’ai brûlé leurs corps. Je suis allé à Delphes pour demander conseil à la Pythie et elle m’a redirigé vers toi.",
        "Vers moi ? Et que veux-tu que je fasse ? Ce sont tes crimes, je n’ai rien à voir avec ça. Va voir ailleurs.",
        "Pour expier mes fautes, je dois me mettre à ton service pendant douze ans.",
        "Intéressant, laisse-moi réfléchir un instant.",
        "*murmurant à l’oreille d’Eurysthée* : demande-lui de tuer le lion de Némée.",
        "Bonne idée, va dans la forêt de Némée. Tu y trouveras un lion qui dévore tout ce qui traverse son chemin. Tue-le et apporte-moi sa peau. Je te confierai ensuite ta prochaine tâche.",
    };


    public bool GetIsTalking()
    {
        return _isTalking;
    }

    public override void Talk()
    {
        _dialManager.SimpleDial(_str[0], gameObject, "Eurysthée");
    }

    public override bool ContinueTalk()
    {
        ++_currDialogue;
        if (!(_currDialogue < _str.Length)) {
                _isTalking = false;
                return false;
            }
        _dialManager.SimpleDial(_str[_currDialogue], gameObject, _pnjName[_currDialogue]);
        return true;
    }
}
