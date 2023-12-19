using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDoors : InterectableObject
{
    public ECharacterType[] CanOpenDoors;

    public override void StartInteractions(GameObject owner, GameObject player)
    {
        Character c = owner.GetComponent<Character>();
        foreach (var characterType in CanOpenDoors)
        {
            if(c.CharacterType == characterType)
            {
                Destroy(this.gameObject);
                AudioManager.instance.PlaySong("Door");
                return;
            }
        }
        AudioManager.instance.PlaySong("DoorClosed");

    }
}
