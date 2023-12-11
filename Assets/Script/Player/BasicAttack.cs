using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    private Character character;
    private FireBall fireball;
    private MovePlayer playerMove;

    public GameObject FireBall;

    public int ProjectileForce = 10;

    private float currentCooldown;

    void Start()
    {
        character = GetComponent<Character>();
        fireball = GetComponent<FireBall>();
        playerMove = GetComponent<MovePlayer>();

        currentCooldown = character.CurrentCD;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown > 0f || playerMove.InMovement)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
            currentCooldown = character.CurrentCD;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RangedAttack();
            currentCooldown = character.CurrentCD;
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
                if (!stat.IsAlive()) 
                {
                    Destroy(eHit);
                }
            }
        }
    }

    public void RangedAttack()
    {
        GameObject fireball = Instantiate(FireBall, transform.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * ProjectileForce;
    }
}
