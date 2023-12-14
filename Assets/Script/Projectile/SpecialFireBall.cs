using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpecialFireBall : MonoBehaviour
{
    public float Radius = 4.5f;
    public float Damage = 10f;

    public Action<EnemyStat> onEnemyKill;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] AttackSphere = Physics.OverlapSphere(collision.gameObject.transform.position, Radius);
        foreach (Collider collider in AttackSphere)
        {
            GameObject gHit = collider.gameObject;
            if (gHit.TryGetComponent<EnemyStat>(out var estat))
            {
                estat.TakeDmg(Damage);
                if (!estat.IsAlive())
                {
                    onEnemyKill?.Invoke(estat);
                    Destroy(gHit.gameObject);
                }
            }
            else if (gHit.TryGetComponent<PlayerDamage>(out var pstat))
            {
                pstat.TakeDamageCurrentCharacter(Damage);
            }
        }
        Destroy(this.gameObject);
    }
}
