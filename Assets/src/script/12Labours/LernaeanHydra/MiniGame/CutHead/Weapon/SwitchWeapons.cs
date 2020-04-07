using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject _blade;
    public GameObject _torch;
    private int _current = 0; //0: blade, 1: torch

    // Start is called before the first frame update
    void Start()
    {
        _torch.SetActive(false);
        _blade.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SwapToBlade()
    {
        if (_current != 0) {
            _current = 0;
            _torch.SetActive(false);
            _blade.SetActive(true);
        }
    }

    public void SwapToTorch()
    {
        if (_current != 1)
        {
            _current = 1;
            _torch.SetActive(true);
            _blade.SetActive(false);
        }
    }
}
