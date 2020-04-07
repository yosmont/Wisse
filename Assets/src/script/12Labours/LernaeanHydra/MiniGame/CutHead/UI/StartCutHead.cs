using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCutHead : MonoBehaviour
{
    public List<GameObject> _toActivate;
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject elem in _toActivate) {
            elem.SetActive(false);
        }
        _button = GetComponent<Button>();
        _button.onClick.AddListener(delegate { startGame(); });
    }

    // Update is called once per frame
    void Update()
    {
    }

    void startGame()
    {
        foreach(GameObject elem in _toActivate) {
            elem.SetActive(true);
        }
        Destroy(gameObject);
    }
}
