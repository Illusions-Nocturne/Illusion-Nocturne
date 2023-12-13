using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private float dist;
    [SerializeField]private Vector3 fictPos;
    private int tileSize = 3;
    private float distForMove = 3.5f;
    private GameObject player;
    private enum Direction
    {
        North,
        East,
        South,
        West,
        None
    };
    private Direction lastDir = Direction.None;
    [SerializeField]private List<Vector3> possibleDir = new List<Vector3>();
    [SerializeField]private List<Vector3> path = new List<Vector3>();
    [SerializeField]private Dictionary<float, Vector3> tempDir = new Dictionary<float, Vector3>();
    [SerializeField]private float shortDist;

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
        fictPos = transform.position;
        FindPath();
        for (int i = 0; i < path.Count; i++)
        {
            print(path);
            transform.position += path[i];
        }
        yield return new WaitForSeconds(1);
        path.Clear();
        tempDir.Clear();
        shortDist = 300;
        StartCoroutine(EMovement());

    }
    private void FindPath()
    {
        dist = Vector3.Distance(fictPos, player.transform.position);
        if (dist > distForMove)
        {
            CheckPossiblePath();
            for (int i = 0; i < possibleDir.Count; i++)
            {
                tempDir.Add(Vector3.Distance(possibleDir[i], player.transform.position), possibleDir[i]);
            }
            possibleDir.Clear();
            path.Add(tempDir[CheckMinDist()]);
        }
    }
    private void CheckPossiblePath()
    {
        if (!ThereIsObstacle(Vector3.forward) && lastDir != Direction.North)
        {
            possibleDir.Add(Vector3.forward*tileSize);
            lastDir = Direction.North;
        }
        if (!ThereIsObstacle(-Vector3.forward) && lastDir != Direction.South)
        {
            possibleDir.Add(-(Vector3.forward * tileSize));
            lastDir = Direction.South;
        }
        if (!ThereIsObstacle(Vector3.right) && lastDir != Direction.East)
        {
            possibleDir.Add(Vector3.right * tileSize);
            lastDir = Direction.East;
        }
        if (!ThereIsObstacle(-Vector3.right) && lastDir != Direction.West)
        {
            possibleDir.Add(-(Vector3.right * tileSize));
            lastDir = Direction.West;
        }
    }
    private float CheckMinDist()
    {
        foreach (KeyValuePair<float, Vector3> tempComp  in tempDir)
        {
            if (shortDist > tempComp.Key)
            {
                shortDist = tempComp.Key;
            }
        }
        return shortDist;
    }
    private bool ThereIsObstacle(Vector3 dir)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out var hit, tileSize))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            return true;
        }
        return false;
    }
}
