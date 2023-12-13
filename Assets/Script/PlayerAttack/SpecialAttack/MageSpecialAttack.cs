using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSpecialAttack : SpecialAttack
{
    public GameObject SpecialFireBall;
    public float Force = 25;
    public float SpawnRange = 1.25f;
    public float DamageMultiplier = 0.75f;

    public override bool StartSpecialAttack(GameObject owner)
    {
        GameObject specialFireBall = Instantiate(SpecialFireBall, owner.transform.position + (owner.transform.forward * SpawnRange), Quaternion.identity);
        specialFireBall.GetComponent<Rigidbody>().velocity = owner.transform.TransformDirection(Vector3.forward) * Force;
        specialFireBall.GetComponent<SpecialFireBall>().Damage = owner.GetComponent<Character>().CurrentAtk * DamageMultiplier;    
        return true;
    }
}
