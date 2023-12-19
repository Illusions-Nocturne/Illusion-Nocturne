using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class GridBehaviour : MonoBehaviour
{
    private Coroutine coroutine;
    float range = 3;
    [SerializeField] private List<Vector3> possiblDir = new List<Vector3>();
    [SerializeField] private List<Vector3> dir = new List<Vector3>();
    [SerializeField] public Vector3 fictPos;
    private bool attack;
    [SerializeField]private GameObject player;
    [SerializeField] private float speedMovement = 10f;
    [SerializeField] private float damage;

    private void Start()
    {
        //thereIsObstacle(Vector3.forward);
        player = GameObject.Find("Player");
        fictPos = transform.localPosition;
        StartCoroutine(MoveEnnemy());
    }
    IEnumerator StartAttack()
    {
        yield return null;
    }
    IEnumerator MoveEnnemy()
    {
        yield return new WaitForSeconds(1f);
        FindColl();
    }
    
    void FindColl() {
        attack = false;
        Debug.Log("test");
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
            StartCoroutine(MoveEnnemy());
        else
            StartCoroutine(Move(findClosest()));
    }

    private Vector3 findClosest()
    {
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
    