using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotationEnnemi : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target);
    }
}
