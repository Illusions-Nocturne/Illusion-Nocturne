using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float MaxAtk = 1;

    public float MaxHp = 50;

    public float MaxExp = 20;

    public float MaxSpeed = 20;

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; private set; }

    public float CurrentSPD { get; private set; }

    public bool IsActive { get; set; }

    void Start()
    {
        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CurrentSPD = MaxSpeed;
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
