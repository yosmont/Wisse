using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : Singleton<Config>
{
    protected Config() { }

    public string sceneToLoad = "";
    public int loadingScene = 0;
    public float loadingProgress = 0f;
}
