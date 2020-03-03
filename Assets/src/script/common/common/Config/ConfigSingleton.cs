using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSingleton : MonoBehaviour
{
    private static ConfigSingleton _instance;

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
