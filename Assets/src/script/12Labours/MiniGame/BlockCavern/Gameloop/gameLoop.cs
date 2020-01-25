using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameLoop : MonoBehaviour
{
    public Transform[] _rock;
    public Transform[] _rockContainer;

    public string _levelPath;

    public Image _black;
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool check = true;
        for (int i = 0; i < _rock.Length; ++i)
            if (_rock[i].position != _rockContainer[i].position) {
                check = false;
                break;
            }
        if (check == true)
            StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        _anim.SetBool("Fade", true);
        yield return new WaitUntil(() => _black.color.a == 1);
        SceneManager.LoadScene("src/scene/" + _levelPath);
    }

}
