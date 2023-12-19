using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStat))]
public class FakeComforterAttack : MonoBehaviour
{
    public float AttackDistance = 3f;
    public float DelayAttack = 1f;

    private EnemyStat stat;
    private WaitForSeconds delayAttackTimer = new WaitForSeconds(1f);

    private void Start()
    {
        stat = GetComponent<EnemyStat>();
    }
    private void OnValidate()
    {
        delayAttackTimer = new WaitForSeconds(DelayAttack);
    }

    public void StartAttackPlayer()
    {
        StartCoroutine(AttackPlayer());
    }

    private IEnumerator AttackPlayer()
    {
        while (true)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward), Color.red, 14f);
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.forward), out var hit, AttackDistance))
            {
                GameObject gHit = hit.transform.gameObject;
                if (gHit.TryGetComponent<PlayerDamage>(out var pd))
                {
                    pd.TakeDamageCurrentCharacter(stat.CurrentAtk);
                }
            }
            yield return delayAttackTimer;
        }
    }
}
