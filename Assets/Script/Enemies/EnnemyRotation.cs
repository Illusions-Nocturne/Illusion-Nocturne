using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnnemyRotation : MonoBehaviour
{
    public Transform target;
    public Vector3 OffsetRotation;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
        target = player.transform;
    }

    void Update()
    {
        transform.LookAt(target, Vector3.up);
        transform.eulerAngles += OffsetRotation;
        transform.eulerAngles = new Vector3(
            0f,
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}
