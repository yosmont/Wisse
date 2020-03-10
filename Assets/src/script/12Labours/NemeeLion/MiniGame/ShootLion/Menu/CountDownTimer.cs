using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    private float _currentTime = 0f;
    private float _startingTime = 15f;
    [SerializeField] Text _countDownText = null;

    public StartMenu _menu = null;

    void Start()
    {
        _currentTime = _startingTime;
        _countDownText.text = "00";
    }

    void Update()
    {
        _currentTime -= 1 * Time.deltaTime;
        _countDownText.text = _currentTime.ToString("0");

        if (_currentTime <= 0)
        {
            _menu.End();
            _currentTime = _startingTime;
            _countDownText.text = _currentTime.ToString("0");
        }
    }
}
