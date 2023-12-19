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
        FindPath();
        yield return new WaitForSeconds(1);
        possiblDir.Clear();
        StartCoroutine(MoveEnnemy());
    }
    private void FindPath()
    {
        FindColl();
        Movement();
    }
    
    void FindColl() {
        //check north
        if (!thereIsObstacle(Vector3.forward))
        {
            possiblDir.Add(transform.localPosition + (Vector3.forward * range));
        }
        //check south
        if (!thereIsObstacle(-Vector3.forward))
        {
            possiblDir.Add(transform.localPosition + (-Vector3.forward * range));
        }
        //check east
        if (!thereIsObstacle(Vector3.right))
        {
            possiblDir.Add(transform.localPosition + (Vector3.right * range));
        }
        //check west
        if (!thereIsObstacle(-Vector3.right))
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

    void Movement()
    {
        transform.position = findClosest();
    }

    private bool thereIsObstacle(Vector3 dir)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out var hit, range))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(dir), Color.red, 20f);

            if(hit.collider.tag == "Player")
            {
                canAttack = true;
                return true;
            }

            return true;    
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(dir), Color.green, 20f);
        return false;
    }
}
    