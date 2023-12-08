using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool inMovement;
    public float timer;
    float dist;
    Vector3 movementTarget;

    // Update is called once per frame
    void Update()
    {
        if(!inMovement)
        {
            StartCoroutine(EMovement());
        }
    }
    IEnumerator EMovement()
    {
        ChoosePosition();
        inMovement = true;
        do
        {
            print("boo");
            transform.position = Vector3.Lerp(transform.position, movementTarget, Time.deltaTime);
            dist = Vector3.Distance(transform.position, movementTarget);
            yield return null;  
        }               
        while (dist > .3f);
        inMovement = false;
    }
    void ChoosePosition()
    {
        switch(Random.Range(0, 4))
        {
            case 0:
                movementTarget = Vector3.forward;
                break;
            case 1:
                movementTarget = -Vector3.forward;
                break;
            case 2:
                movementTarget = Vector3.right;
                break;
            case 3:
                movementTarget = -Vector3.right;
                break;
            default:
                break;
        }
        movementTarget += movementTarget + transform.position;
    }
}
