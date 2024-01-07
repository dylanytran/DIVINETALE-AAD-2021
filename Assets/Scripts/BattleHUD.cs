using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text name;
    public Text level;
    public Text hp;
    public Slider healthBar;

    public void SetHUD(Stats stat) {
        name.text = stat.name;
        level.text = "Lvl." + stat.level;
        hp.text = stat.currentHP + " / " + stat.maxHP;
        healthBar.maxValue = stat.maxHP;
        healthBar.value = stat.currentHP;
    }

    public void SetHP(int hp) {
        healthBar.value = hp;
    }
}
