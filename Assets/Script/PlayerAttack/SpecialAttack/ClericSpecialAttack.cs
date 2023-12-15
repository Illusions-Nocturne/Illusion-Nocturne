using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Collections.LowLevel.Unsafe;
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
        int healNumber = 0;

        if (NumberHealPerStage <= 0)
            return false;

        foreach (Character c in character) 
        {
            if (c.IsAlive() && c.CurrentHp != c.MaxHp)
            {
                c.HealNb(c.MaxHp * HealAmount);
                healNumber++;
                AudioManager.instance.PlaySong("Heal");
            }
            healthBar.UpdateHealthBar();
        }
        NumberHealPerStage--;
        return healNumber > 0;
    }
}
