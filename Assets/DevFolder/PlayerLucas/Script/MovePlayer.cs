using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private bool inMovement = false;
    private int counter;
    private bool rotate;
    private bool inRotate;
    [SerializeField] private int speedRotation = 3;
    [SerializeField] private float movDistance = 3f;

    void Update()
    {
        if (inMovement || rotate)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!thereIsObstacle(Vector3.forward))
                StartCoroutine(Move(transform.position + (transform.forward * movDistance)));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!thereIsObstacle(-Vector3.forward))
                StartCoroutine(Move(transform.position + (-transform.forward * movDistance)));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!thereIsObstacle(-Vector3.right))
                StartCoroutine(Move(transform.position + (-transform.right * movDistance)));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!thereIsObstacle(Vector3.right))
                StartCoroutine(Move(transform.position + (transform.right * movDistance)));
        }
        if ((Input.GetKeyDown(KeyCode.Q) || rotate) && !inRotate)
        {
            rotate = true;
            if (counter == 90)
            {
                rotate = false;
                counter = 0;
            }
            else if (rotate)
            {
                transform.Rotate(0.0f, -speedRotation, 0.0f, Space.Self);
                counter += speedRotation;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) || rotate)
        {
            inRotate = true;
            rotate = true;
            if (counter == 90)
            {
                rotate = false;
                counter = 0;
                inRotate = false;
            }
            else if (rotate)
            {
                transform.Rotate(0.0f, speedRotation, 0.0f, Space.Self);
                counter += speedRotation;
            }
        }
    }
    private IEnumerator Move(Vector3 dest)
    {
        inMovement = true;
        float dist;
        do
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * 10.0f);
            dist = Vector3.Distance(transform.position, dest);
            yield return null;
        }
        while (dist > .3f);
        inMovement = false;
        transform.position = dest;
    }

    private bool thereIsObstacle(Vector3 dir)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out var hit, movDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            return true;
        }

        return false;
    }
}
