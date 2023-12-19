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
    private bool canAttack;
    [SerializeField]private GameObject player;
    private bool inMovement = false;
    [SerializeField] private float speedMovement = 10f;
    [SerializeField] private float damage;

    private void Start()
    {
        //thereIsObstacle(Vector3.forward);
        player = GameObject.Find("Player");
        fictPos = transform.localPosition;
        MoveEnnemy();
    }
    IEnumerator StartAttack()
    {
        yield return null;
    }
    void MoveEnnemy()
    {
        FindPath();
    }
    private void FindPath()
    {
        FindColl();
        StartCoroutine(Move(findClosest()));
    }
    
    void FindColl() {
        //check north
        if (!thereIsObstacle(Vector3.forward, out var pf))
        {
            possiblDir.Add(transform.localPosition + (Vector3.forward * range));
        }
        //check south
        if (!thereIsObstacle(-Vector3.forward, out var pb))
        {
            possiblDir.Add(transform.localPosition + (-Vector3.forward * range));
        }
        //check east
        if (!thereIsObstacle(Vector3.right, out var pr))
        {
            possiblDir.Add(transform.localPosition + (Vector3.right * range));
        }
        //check west
        if (!thereIsObstacle(-Vector3.right, out var pl))
        {
            possiblDir.Add(transform.localPosition + (-Vector3.right * range));
        }
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
        inMovement = true;
        float dist;
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * speedMovement);
            dist = Vector3.Distance(transform.position, dest);
            yield return null;
        }
        while (dist > .3f);

        transform.position = dest;
        inMovement = false;

        yield return new WaitForSeconds(1);
        possiblDir.Clear();
        MoveEnnemy();
    }

    private bool thereIsObstacle(Vector3 dir, out GameObject p)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out var hit, range))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(dir), Color.red, 20f);

            if(hit.collider.tag == "Player")
            {
                canAttack = true;
                p = hit.collider.gameObject;
                return true;
            }

            p = null;
            return true;    
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(dir), Color.green, 20f);
        p = null;
        return false;
    }
}
    