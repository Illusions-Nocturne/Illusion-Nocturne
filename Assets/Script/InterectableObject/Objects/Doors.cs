using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : InterectableObject
{
    public bool canOpen = true;
    public override void StartInteractions(GameObject owner, GameObject player)
    {
        AudioManager.instance.PlaySong("Door");
        if (canOpen)
        {
            this.gameObject.SetActive(false);
        }
    }
}
