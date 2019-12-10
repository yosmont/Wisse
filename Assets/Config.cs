using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : Singleton<Config>
{
    protected Config() { }

    public int sceneToLoad = -1;
    public int loadingScene = 0;
    public float loadingProgress = 0f;
}
