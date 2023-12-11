using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    private Character character;

    public float AtkDistance = 3f;

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
    }
}
