using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CampagneScenario : MonoBehaviour
{
    public Image black;
    public Animator anim;

    private bool hasSleep = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (black.color.a == 1 && !hasSleep && GameObject.Find("Molorchos").GetComponent<MolorchosDialogue>().alreadyTalk)
            StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        hasSleep = true;
        anim.SetBool("Sleeped", true);
        anim.SetBool("Fade", false);
        yield return new WaitUntil(() => black.color.a == 0);
    }
}
