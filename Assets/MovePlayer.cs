using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private bool inMovement = false;
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Move(transform.position + (-transform.forward * movDistance)));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Move(transform.position + (-transform.right * movDistance)));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Move(transform.position + (transform.right * movDistance)));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
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
