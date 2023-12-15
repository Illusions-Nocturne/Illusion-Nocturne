using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float MaxAtk = 1;

    public float MaxHp = 50;

    public float MaxCD = 3;

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; private set; }

    public float CurrentCD { get; private set; }

    public bool IsActive { get; set; }

    void Start()
    {
        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CurrentCD = MaxCD;
        IsActive = false; 
    }

    public void TakeDmg(float playerDmg) 
    {
        CurrentHp -= playerDmg;
    }

    public bool IsAlive()
    {
        return CurrentHp > 0;
    }
}
