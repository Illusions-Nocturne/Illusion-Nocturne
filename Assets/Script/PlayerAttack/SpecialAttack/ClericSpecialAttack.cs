using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class ClericSpecialAttack : SpecialAttack
{
    public float HealAmount = 0.1f;
    public int NumberHealPerStage = 5;
    public Character[] character;
    public PlayerDamage healthBar;

    public override bool StartSpecialAttack(GameObject owner)
    {
        if (NumberHealPerStage <= 0)
            return false;

        foreach (Character c in character) 
        {
            c.HealNb(c.MaxHp * HealAmount);
            healthBar.UpdateHealthBar();
            NumberHealPerStage--;
        }
        return true;
    }
}
