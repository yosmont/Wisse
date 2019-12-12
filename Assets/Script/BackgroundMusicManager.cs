using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public string[] MusicName;
    public AudioClip[] MusicClip;
    [HideInInspector]
    public string current;
    private Dictionary<string, AudioClip> MusicList = new Dictionary<string, AudioClip>();
    private AudioSource src;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        src = GetComponent<AudioSource>();
        for (int i = 0; i < MusicName.Length; ++i)
            MusicList.Add(MusicName[i], MusicClip[i]);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play(string name)
    {
        if (current == name)
            return;
        AudioClip res = MusicList[name];
        if (res != null) {
            current = name;
            src.Stop();
            src.clip = res;
            src.Play();
        }
    }
}
