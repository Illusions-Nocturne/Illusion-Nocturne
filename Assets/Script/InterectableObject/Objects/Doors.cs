using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : InterectableObject
{
    public override void StartInteractions(GameObject owner, GameObject player)
    {
        Destroy(this.gameObject);
    }
}
