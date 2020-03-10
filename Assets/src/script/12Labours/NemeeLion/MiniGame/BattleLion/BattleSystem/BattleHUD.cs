using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text _nameText;
    public Slider _hpSlider;

    public void SetHUD(Unit unit)
    {
        _nameText.text = unit.unitName;
        _hpSlider.maxValue = unit.maxHp;
        _hpSlider.value = unit.currentHp;
    }

    public void setHP(int HP)
    {
        _hpSlider.value = HP;
    }
}
