using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnHead : MonoBehaviour
{
    public GameObject _headPrefab;
    public int _nbHeadTotal = 3;
    public int _nbHeadMax = 7;
    public float _timeBetweenSpawn = 2f;
    public string _winLevelPath = "";
    public string _lostLevelPath = "";
    private float _timer;
    private int _nbHead = 0;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (_nbHead != _nbHeadTotal) {
            if (_timer <= 0) {
                Instantiate(_headPrefab, new Vector3(0, -10, 0), new Quaternion());
                ++_nbHead;
                if (_nbHead >= _nbHeadMax)
                    Lost();
                _timer = _timeBetweenSpawn;
            } else {
                _timer -= Time.deltaTime;
            }
        }
    }

    void Win()
    {
        SceneManager.LoadScene("src/scene/" + _winLevelPath);
    }

    void Lost()
    {
        SceneManager.LoadScene("src/scene/" + _lostLevelPath);
    }

    public void AddHead()
    {
        --_nbHead;
        ++_nbHeadTotal;
    }

    public void AddBurnHead()
    {
        --_nbHead;
        --_nbHeadTotal;
        if (_nbHeadTotal == 0)
            Win();
    }
}
