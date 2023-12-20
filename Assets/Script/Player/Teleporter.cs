using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform[] tpPoints;

    private MovePlayer move;

    private void Start()
    {
        move = GetComponent<MovePlayer>();
    }

    public void TeleportToTransform(int index)
    {
        move.StopMovement();
        transform.position = tpPoints[index].position;
    }
}
