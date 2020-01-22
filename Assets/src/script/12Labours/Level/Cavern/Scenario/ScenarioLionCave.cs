using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioLionCave : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _heracles;
    private Vector3 _pos;

    void Start()
    {
        _player = GameObject.Find("player");
        _heracles = _player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int currentStep = _player.GetComponent<DialogueCave>().GetStep();
        _pos = _heracles.position;
        if (_pos.x >= 5 && currentStep < 1)
            _player.GetComponent<APNJTalk>().Talk();
        if (_pos.x >= 9 && _pos.y <= 0 && currentStep < 2)
            _player.GetComponent<APNJTalk>().Talk();
    }
}
