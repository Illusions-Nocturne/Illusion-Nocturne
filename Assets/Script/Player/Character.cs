using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public BaseStats stats;

    public float Atk { get; private set; }

    public float Hp { get; private set; }

    public float CD { get; private set; }

    public float PercentAtk = 100;
    public float PercentHp = 100;
    public float PercentCD = 100;

    private void Start()
    {
        stats = GetComponent<BaseStats>();
        CharacterStats();
    }

    public void CharacterStats()
    {
        Atk = stats.Atk * PercentAtk / 100;
        Hp = stats.Hp * PercentHp / 100;
        CD = stats.CD * PercentCD / 100;
    }
    private void takeDMG(float enemyDMG)
    {
        PercentHp -= enemyDMG;
    }
}
