using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageSpecialAttack : SpecialAttack
{
    public GameObject SpecialFireBall;
    public float Force = 25;

    public override void StartSpecialAttack(GameObject owner)
    {
        GameObject specialFireBall = Instantiate(SpecialFireBall, owner.transform.position + (owner.transform.forward * 1.25f), Quaternion.identity);
        specialFireBall.GetComponent<Rigidbody>().velocity = owner.transform.TransformDirection(Vector3.forward) * Force;
        specialFireBall.GetComponent<SpecialFireBall>().Damage = owner.GetComponent<Character>().CurrentAtk * 0.75f;       
    }
}
