using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public BaseStats stats;

    public PlayerDamage UpdateLevel;

    public float MaxAtk { get; private set; }

    public float MaxHp { get; private set; }

    public float MaxCD { get; private set; }

    public float MaxExp { get; private set; } = 100;

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; set; }

    public float CurrentCD { get; set; }

    public float CurrentExp { get; set; }

    public int Level { get; set; } = 1;

    public float PercentAtk = 100;
    public float PercentHp = 100;
    public float PercentCD = 100;

    public float CDBaseAttack;
    public float CDSpecialAttack;

    public float IncreaseMaxExp = 1.1f;
    public float IncreaseCurrentAttack = 1.1f;
    public float IncreaseMaxHealth = 1.1f;

    public ECharacterType CharacterType;

    [HideInInspector] public bool CanTakeDamage = true;

    private void Start()
    {
        CharacterStats();
    }

    public void SetCanTakeDamage(bool enable) => CanTakeDamage = enable;

    public void CharacterStats()
    {
        stats = GetComponent<BaseStats>();

        MaxAtk = stats.Atk * PercentAtk / 100;
        MaxHp = stats.Hp * PercentHp / 100;
        MaxCD = stats.CD * PercentCD / 100;

        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CDBaseAttack = MaxCD;
    }

    public void TakeDmg(float enemyDMG)
    {
        if (!CanTakeDamage)
            return;

        CurrentHp -= enemyDMG;
    }

    public void SetHealthPoint(float newHealthPoint)
    {
        CurrentHp = newHealthPoint;
    }

    public bool IsAlive() 
    {
        return CurrentHp > 0;
    }

    public void HealNb(float Heal)
    {
        CurrentHp = Mathf.Min(CurrentHp + Heal, MaxHp);
    }

    public void AddExp(float exp) 
    {
        CurrentExp += exp;
        if (CurrentExp >= MaxExp)
        {
            LevelUp();
        }
    }

    public void LevelUp() 
    {

        CurrentExp -= MaxExp;
        Level++;
        MaxExp *= IncreaseMaxExp;
        CurrentAtk *= IncreaseCurrentAttack;
        MaxHp *= IncreaseMaxHealth;
        CurrentHp = MaxHp;
        AudioManager.instance.PlaySong("LevelUp");
        UpdateLevel.UpdateLevelBar();

        if (CurrentExp >= MaxExp)
        {
            LevelUp();
        }
    }
}
