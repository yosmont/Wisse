using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHead : MonoBehaviour
{
    public GameObject _headPrefab;
    public int _nbHeadTotal = 3;
    public int _nbHeadMax = 9;
    public float _timeBetweenSpawn = 2f;
    private float _timer;
    private int _nbHead = 0;
    private int _nbBurnHead = 0;

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
        Debug.Log("You win!");
    }

    void Lost()
    {
        Debug.Log("You lost!");
    }

    public void AddHead()
    {
        _nbHeadTotal += 2;
    }

    public void AddBurnHead()
    {
        ++_nbBurnHead;
        if (_nbHeadTotal == _nbBurnHead)
            Win();
    }
}
