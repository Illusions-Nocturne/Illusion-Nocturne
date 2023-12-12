using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform[] tpPoints;

    public void TeleportToTransform(int index)
    {
        transform.position = tpPoints[index].position;
    }
}
