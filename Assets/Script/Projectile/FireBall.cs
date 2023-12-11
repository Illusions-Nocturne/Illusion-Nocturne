using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class FireBall : MonoBehaviour
{
    private Character character;

    [SerializeField]
    private EnemyStat enemystat;

    void Start()
    {
        character = GameObject.Find("Player").GetComponent<Character>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemystat = collision.gameObject.GetComponent<EnemyStat>();
            enemystat.TakeDmg(character.CurrentAtk * 0.5f);
            if (!enemystat.IsAlive())
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Door"))
        {
            Destroy(gameObject);
        }
    }
}