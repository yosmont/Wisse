using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CampagneScenario : MonoBehaviour
{
    public Image _black;
    public Animator _anim;

    private bool _hasSleep = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (_black.color.a == 1 && !_hasSleep && GameObject.Find("Molorchos").GetComponent<MolorchosDialogue>().GetAlreadyTalk())
            StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        _hasSleep = true;
        _anim.SetBool("Sleeped", true);
        _anim.SetBool("Fade", false);
        yield return new WaitUntil(() => _black.color.a == 0);
    }
}
