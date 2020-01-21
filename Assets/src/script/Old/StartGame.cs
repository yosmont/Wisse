using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] Text startGameText = null;

    void Start()
    {
        GameObject.Find("CountDownText").GetComponent<CountDownTimer>().enabled = false;
        GameObject.Find("lion").GetComponent<LionMove>().enabled = false;
        startGameText.text = "Lol";
        print("lol");
    }

    void Update()
    {
        if (Input.touches[0].phase == TouchPhase.Began)
        {
            GameObject.Find("CountDownText").GetComponent<CountDownTimer>().enabled = true;
        }
    }

    public void Win()
    {
        GameObject.Find("CountDownText").GetComponent<CountDownTimer>().enabled = false;
        startGameText.text = "Mes flèches lui rebondissent dessus, en plus il s'est enfui.";
    }

    public void Loose()
    {
        GameObject.Find("CountDownText").GetComponent<CountDownTimer>().enabled = false;
        startGameText.text = "Il faut que je réessaye.";
    }
}
