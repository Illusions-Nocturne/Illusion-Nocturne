using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    private Character character;

    void Start()
    {
        character = GetComponent<Character>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    public void Attack() 
    { 
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, 3f))
        {
            GameObject eHit = hit.collider.gameObject;
            if (eHit.TryGetComponent<EnemyStat>(out var stat)) 
            {
                stat.TakeDmg(character.CurrentAtk);
            }
        }
    }
}
