using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsControler : MonoBehaviour
{
    public List<string> _tipList = new List<string>() {
        "Les réfrigérateurs sont moins chers chez BUT",
        "Si juvabien c'est juvamine",
        "Le prince dragon vit dans son château",
        "Le prince Hordkhen est un terrible compagnon",
        "Les princes dragon contrôlent les éléments"
    };
    public List<int> _alreadyGet;
    public float _timeBetweenTips = 3f;
    private float _timer = 0f;
    private TMPro.TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
        _text.text = GetTips();
    }

    private void Update()
    {
        if (_tipList.Count != _alreadyGet.Count) {
            _timer += Time.deltaTime;
            if (_timer >= _timeBetweenTips) {
                _timer = 0f;
                _text.text = GetTips();
            }
        }
    }

    private string GetTips()
    {
        int i = Random.Range(0, _tipList.Count);
        while (_alreadyGet.Exists(x => x == i))
            i = Random.Range(0, _tipList.Count);
        _alreadyGet.Add(i);
        return _tipList[i];
    }
}
