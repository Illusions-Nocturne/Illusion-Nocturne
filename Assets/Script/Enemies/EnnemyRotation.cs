using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnnemyRotation : MonoBehaviour
{
    public Transform target;
    public Vector3 OffsetRotation;

    void Update()
    {
        transform.LookAt(target, Vector3.up);
        transform.eulerAngles += OffsetRotation;
    }
}
