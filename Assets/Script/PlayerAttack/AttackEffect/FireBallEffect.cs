using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEffect : AttackEffect
{
    public GameObject FireBall;
    public float Force = 10;

    public override void BeginEffect(GameObject owner)
    {
        GameObject fireBall = Instantiate(FireBall, owner.transform.position + (owner.transform.forward), Quaternion.identity);
        fireBall.GetComponent<Rigidbody>().velocity = owner.transform.TransformDirection(Vector3.forward) * Force;
        fireBall.GetComponent<FireBall>().Damage = owner.GetComponent<Character>().CurrentAtk * 0.5f;
    }
}
