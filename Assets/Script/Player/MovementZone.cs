using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementZone : MonoBehaviour
{
    private GameObject owner;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gHit = other.gameObject;
        if (gHit.name.Equals(owner.name))
        {
            Destroy(this.gameObject);
        }
    }

    public void InitializeMovementZone(GameObject _o)
    {
        owner = _o;
    }
}
