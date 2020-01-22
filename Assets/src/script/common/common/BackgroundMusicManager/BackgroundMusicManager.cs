using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public string[] _musicName;
    public AudioClip[] _musicClip;
    private string _current;
    private Dictionary<string, AudioClip> _musicList = new Dictionary<string, AudioClip>();
    private AudioSource _src;
    private static BackgroundMusicManager _instance;

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            _src = GetComponent<AudioSource>();
            for (int i = 0; i < _musicName.Length; ++i)
                _musicList.Add(_musicName[i], _musicClip[i]);
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

    public string GetCurrent()
    {
        return _current;
    }

    public void Play(string name)
    {
        if (_current == name)
            return;
        AudioClip res = _musicList[name];
        if (res != null) {
            _current = name;
            _src.Stop();
            _src.clip = res;
            _src.Play();
        }
    }
}
