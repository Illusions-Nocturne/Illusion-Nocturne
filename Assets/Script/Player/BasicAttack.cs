using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BasicAttack : MonoBehaviour
{
    private Character character;

    public float AtkDistance = 3f;
    public AttackEffect[] OnAttackComplete;

    void Start()
    {
        character = GetComponent<Character>();
    }

    public void Attack() 
    { 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, AtkDistance))
        {
            GameObject eHit = hit.collider.gameObject;
            if (eHit.TryGetComponent<EnemyStat>(out var stat)) 
            {
                stat.TakeDmg(character.CurrentAtk);
                if (!stat.IsAlive()) 
                {
                    Destroy(eHit);
                }
            }
        }

        if (OnAttackComplete.Length > 0) 
        { 
            foreach (AttackEffect effect in OnAttackComplete)
            {
                effect.BeginEffect(this.gameObject);
            }
        }
    }
}
