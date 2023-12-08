using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public float MaxAtk { get; private set; }

    public float MaxHp { get; private set; }

    public float MaxCD { get; private set; }

    public float CurrentAtk { get; private set; }

    public float CurrentHp { get; private set; }

    public float CurrentCD { get; private set; }

    void Start()
    {
        CurrentAtk = MaxAtk;
        CurrentHp = MaxHp;
        CurrentCD = MaxCD;
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
