using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public string name;
    public int level;
    public int damage;
    public int maxHP;
    public int currentHP;

    public void TakeDamage(int dmg) {
        currentHP -= dmg;
    }

    public void Heal(int value) {
        currentHP += value;

        if(currentHP > maxHP) {
            currentHP = maxHP;
        }
    }

    public bool isDead() {
        if(currentHP <= 0)
            return true;
            
        else
            return false;
    }
}
