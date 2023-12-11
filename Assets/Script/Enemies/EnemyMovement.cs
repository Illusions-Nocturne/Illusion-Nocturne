using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool inMovement;
    private float dist;
    private Vector3 moveTarget;
    private float speed = 6f;
    private float moveDistance = 3f;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void Start()
    {
        StartCoroutine(EMovement());
    }

    IEnumerator EMovement()
    {
        Debug.Log(Vector3.Distance(transform.position, moveTarget));
        ChoosePosition();
        inMovement = true;
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
            dist = Vector3.Distance(transform.position, moveTarget);
            yield return null;  
        }               
        while (dist > .0001);
        inMovement = false;
        StartCoroutine(EMovement());

    }
    private void ChoosePosition()
    {
        int checkpos = 0;
        if(transform.position.x > player.transform.position.x)
        {
            checkpos = 4;
        }
        else if (transform.position.x < player.transform.position.x)
        {
            checkpos = 3;
        }
        if (transform.position.z > player.transform.position.z)
        {
            checkpos = 2;
        }
        else if (transform.position.z < player.transform.position.z)
        {
            checkpos = 1;
        }
        switch (checkpos)
        {
            case 1:
                if (!ThereIsObstacle(Vector3.forward))
                    moveTarget = (transform.forward * moveDistance) + transform.position;
                break;
            case 2:
                if (!ThereIsObstacle(-Vector3.forward))
                    moveTarget = (-transform.forward * moveDistance) + transform.position;
                break;
            case 3:
                if (!ThereIsObstacle(Vector3.right))
                    moveTarget = (transform.right * moveDistance) + transform.position;
                break;
            case 4:
                if (!ThereIsObstacle(-Vector3.right))
                    moveTarget = (-transform.right * moveDistance) + transform.position;
                break;
            default: 
                break;
        }
    }
    private bool ThereIsObstacle(Vector3 dir)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out var hit, moveDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            return true;
        }
        return false;
    }
}
