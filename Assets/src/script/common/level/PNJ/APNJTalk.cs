﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APNJTalk : MonoBehaviour
{
    public DialogueManager _dialManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Talk();
    public abstract bool ContinueTalk();
}
