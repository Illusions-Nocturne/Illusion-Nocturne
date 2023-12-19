using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : InterectableObject
{
    public override void StartInteractions(GameObject owner, GameObject player)
    {
        AudioManager.instance.PlaySong("Door");
        this.gameObject.SetActive(false);
    }
}
