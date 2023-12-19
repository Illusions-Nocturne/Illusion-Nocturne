using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTeleporter : MonoBehaviour
{
    [SerializeField] private int indexTeleport = 0;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gHit = collision.gameObject;
        if (gHit.TryGetComponent<Teleporter>(out var t))
        {
            t.TeleportToTransform(indexTeleport);
        }
    }
}
