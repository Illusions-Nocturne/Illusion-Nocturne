using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridBehaviour : MonoBehaviour
{
    private Coroutine coroutine;
    float range = 3;
    [SerializeField] private List<Vector3> possiblDir = new List<Vector3>();
    [SerializeField] private List<Vector3> dir = new List<Vector3>();
    [SerializeField] public Vector3 fictPos;
    private bool attack;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movementZone;
    [SerializeField] private float speedMovement = 10f;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    private EnemyStat enemyStat;
    private Animator animator;

    private GameObject currentMoveZone;
    private GameObject lastMoveZone;

    private void Start()
    {
        enemyStat = GetComponent<EnemyStat>();
        enemyStat.Start();

        speed = enemyStat.CurrentSPD;
        damage = enemyStat.CurrentAtk;
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        fictPos = transform.localPosition;
        StartCoroutine(MoveEnnemy());
    }

    private void OnDestroy()
    {
        if (lastMoveZone)
            Destroy(lastMoveZone);

        if (currentMoveZone)
            Destroy(currentMoveZone);
    }

    IEnumerator MoveEnnemy()
    {
        yield return new WaitForSeconds(speed);
        FindColl();
    }

    private void Update()
    {
        if(animator != null)
        {
            animator.SetBool("attack", attack);
        }
    }

    void FindColl() {
        attack = false;
        //check north
        if (!thereIsObstacle(Vector3.forward, out var pf))
        {
            possiblDir.Add(transform.localPosition + (Vector3.forward * range));

            if (pf)
            {
                possiblDir.Clear();

                if (pf.TryGetComponent<PlayerDamage>(out var d))
                {
                    d.TakeDamageCurrentCharacter(damage);
                    attack = true;
                }
            }
        }
        //check south
        if (!thereIsObstacle(-Vector3.forward, out var pb))
        {
            possiblDir.Add(transform.localPosition + (-Vector3.forward * range));

            if (pb)
            {
                possiblDir.Clear();

                if (pb.TryGetComponent<PlayerDamage>(out var d))
                {
                    d.TakeDamageCurrentCharacter(damage);
                    attack = true;
                }
            }
        }
        //check east
        if (!thereIsObstacle(Vector3.right, out var pr))
        {
            possiblDir.Add(transform.localPosition + (Vector3.right * range));

            if (pr)
            {
                possiblDir.Clear();

                if (pr.TryGetComponent<PlayerDamage>(out var d))
                {
                    d.TakeDamageCurrentCharacter(damage);
                    attack = true;
                }
            }
        }
        //check west
        if (!thereIsObstacle(-Vector3.right, out var pl))
        {
            possiblDir.Add(transform.localPosition + (-Vector3.right * range));

            if (pl)
            {
                possiblDir.Clear();

                if (pl.TryGetComponent<PlayerDamage>(out var d))
                {
                    d.TakeDamageCurrentCharacter(damage);
                    attack = true;
                }
            }
        }

        if (attack)
        {
            StartCoroutine(MoveEnnemy());
        }
        else
        {
            Vector3 d = findClosest();

            if (d.Equals(Vector3.zero))
                StartCoroutine(MoveEnnemy());
            else
                StartCoroutine(Move(d));
        }
    }

    private Vector3 findClosest()
    {
        if (possiblDir.Count < 1)
            return Vector3.zero;

        float tempDist = Vector3.Distance(possiblDir[0], player.transform.position);
        Vector3 tempPos = possiblDir[0];

        foreach (Vector3 point in possiblDir)
        {
            float dist = Vector3.Distance(point, player.transform.position);

            if (dist < tempDist)
            {
                tempDist = dist;
                tempPos = point;
            }
        }
        return tempPos;
    }

    private IEnumerator Move(Vector3 dest)
    {
        if(dest == Vector3.zero)
        {
            StartCoroutine(MoveEnnemy());
            yield return null;
        }

        lastMoveZone = currentMoveZone;
        currentMoveZone = Instantiate(movementZone, dest, Quaternion.identity);

        float dist;
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * speedMovement);
            dist = Vector3.Distance(transform.position, dest);
            yield return null;
        }
        while (dist > .3f);

        transform.position = dest;

        yield return new WaitForSeconds(1);
        if (lastMoveZone)
            Destroy(lastMoveZone);

        possiblDir.Clear();
        StartCoroutine(MoveEnnemy());
    }

    private bool thereIsObstacle(Vector3 dir, out GameObject p)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out var hit, range))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(dir), Color.red, 20f);

            if(hit.collider.gameObject.tag == "Player")
            {
                p = hit.collider.gameObject;
                return false;
            }

            p = null;
            return true;    
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(dir), Color.green, 20f);
        p = null;
        return false;
    }
}
    