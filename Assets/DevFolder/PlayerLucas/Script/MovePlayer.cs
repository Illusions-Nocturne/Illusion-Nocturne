using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private bool inMovement = false;
    [SerializeField] private int speedRotation = 3;
    [SerializeField] private float speedMovement = 10f;
    [SerializeField] private float movDistance = 3f;

    void Update()
    {
        if (inMovement)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!thereIsObstacle(Vector3.forward))
                StartCoroutine(Move(transform.position + (transform.forward * movDistance)));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!thereIsObstacle(-Vector3.forward))
                StartCoroutine(Move(transform.position + (-transform.forward * movDistance)));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (!thereIsObstacle(-Vector3.right))
                StartCoroutine(Move(transform.position + (-transform.right * movDistance)));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!thereIsObstacle(Vector3.right))
                StartCoroutine(Move(transform.position + (transform.right * movDistance)));
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(rotate(new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y - 90f,
                transform.eulerAngles.z
            ), -1f));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(rotate(new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y + 90f,
                transform.eulerAngles.z
            ), 1f));
        }
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
    }

    private IEnumerator rotate(Vector3 dest, float scale)
    {
        inMovement = true;
        float counter = 0;

        while (counter < 90f) 
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y + (speedRotation * scale) * Time.deltaTime,
                transform.eulerAngles.z
            );
            counter += speedRotation * Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = dest;
        inMovement = false;
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
