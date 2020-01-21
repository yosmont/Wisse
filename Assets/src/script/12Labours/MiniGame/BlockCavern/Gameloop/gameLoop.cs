using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameLoop : MonoBehaviour
{
    public Transform rock1;
    public Transform rockContainer1;

    public Transform rock2;
    public Transform rockContainer2;

    public Transform rock3;
    public Transform rockContainer3;

    public Transform rock4;
    public Transform rockContainer4;

    public Transform rock5;
    public Transform rockContainer5;

    public string levelPath;

    public Image black;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rock1.position == rockContainer1.position 
            && rock2.position == rockContainer2.position 
            && rock3.position == rockContainer3.position 
            && rock4.position == rockContainer4.position 
            && rock5.position == rockContainer5.position)
            StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(levelPath);
    }

}
