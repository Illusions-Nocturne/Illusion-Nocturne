using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FireBall : MonoBehaviour
{
    public float Damage;

    public Action<EnemyStat> onEnemyKill;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gHit = collision.gameObject;
        if (gHit.TryGetComponent<EnemyStat>(out var stat))
        {
            AudioManager.instance.PlaySong("HitEnnemis");
            stat.TakeDmg(Damage);
            if (!stat.IsAlive())
            {
                onEnemyKill?.Invoke(stat);
                Destroy(gHit);
            }
        }
        Destroy(this.gameObject);
    }
}
