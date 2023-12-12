using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FireBall : MonoBehaviour
{
    public float Damage;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gHit = collision.gameObject;
        if (gHit.TryGetComponent<EnemyStat>(out var stat))
        {
            stat.TakeDmg(Damage);
            if (!stat.IsAlive())
            {
                Destroy(gHit);
            }
        }
        Destroy(this.gameObject);
    }
}
