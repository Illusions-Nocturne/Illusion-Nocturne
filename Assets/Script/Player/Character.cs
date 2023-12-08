using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public BaseStats stats;

    public float MaxAtk { get; private set; }

    public float MaxHp { get; private set; }

    public float MaxCD { get; private set; }

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; private set; }

    public float CurrentCD { get; private set; }

    public float PercentAtk = 100;
    public float PercentHp = 100;
    public float PercentCD = 100;

    private void Start()
    {
        CharacterStats();
    }

    public void CharacterStats()
    {
        stats = GetComponent<BaseStats>();

        MaxAtk = stats.Atk * PercentAtk / 100;
        MaxHp = stats.Hp * PercentHp / 100;
        MaxCD = stats.CD * PercentCD / 100;

        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CurrentCD = MaxCD;
    }

    public void TakeDmg(float enemyDMG)
    {
        CurrentHp -= enemyDMG;
    }

    public bool IsAlive() 
    {
        return CurrentHp > 0;
    }

    public void HealNb(float ItemHeal)
    {
        CurrentHp = Mathf.Min(CurrentHp + ItemHeal, MaxHp);
    }
}
