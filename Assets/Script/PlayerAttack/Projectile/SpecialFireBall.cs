using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.TextCore.Text;

public class SpecialFireBall : MonoBehaviour
{
    public float Radius = 4.5f;
    public float Damage = 10f;

    public Action<EnemyStat> onEnemyKill;

    public Light LightComponent;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] AttackSphere = Physics.OverlapSphere(collision.gameObject.transform.position, Radius);
        foreach (Collider collider in AttackSphere)
        {
            GameObject gHit = collider.gameObject;
            if (gHit.TryGetComponent<EnemyStat>(out var estat))
            {
                AudioManager.instance.PlaySong("HitEnnemis");
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
        Invoke(nameof(DestroyProjectiles), 0.075f);
        UpdateIntensity();
    }

    private void UpdateIntensity()
    {
        LightComponent.intensity = 15;
    }

    private void DestroyProjectiles()
    {
        Destroy(this.gameObject);
    }
}
