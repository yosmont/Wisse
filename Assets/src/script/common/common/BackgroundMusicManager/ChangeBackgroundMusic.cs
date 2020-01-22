using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundMusic : MonoBehaviour
{
    public string _musicName;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("BMM") != null) {
            BackgroundMusicManager BMM = GameObject.Find("BMM").GetComponent<BackgroundMusicManager>();
            BMM.Play(_musicName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
