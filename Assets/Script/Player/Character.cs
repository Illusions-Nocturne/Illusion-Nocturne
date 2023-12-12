using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public BaseStats stats;

    public float MaxAtk { get; private set; }

    public float MaxHp { get; private set; }

    public float MaxCD { get; private set; }

    public float MaxSpecialCD { get; private set; }

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; private set; }

    public float CurrentCD { get; private set; }

    public float CurrentSpecialCD { get; private set; }

    public float PercentAtk = 100;
    public float PercentHp = 100;
    public float PercentCD = 100;
    public float PercentSpecialCD = 100;

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
        MaxSpecialCD = stats.SpecialCD * PercentSpecialCD / 100;

        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CurrentCD = MaxCD;
        CurrentSpecialCD = MaxSpecialCD;
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
}
