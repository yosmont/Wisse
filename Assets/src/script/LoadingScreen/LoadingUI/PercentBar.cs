using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentBar : MonoBehaviour
{
    private Slider _slider;
    private TMPro.TextMeshProUGUI _percentText;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _percentText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
    }

    public void ChangePercent(float progress)
    {
        _percentText.text = ((int)(progress * 100)) + "%";
        _slider.value = progress;
    }
}
