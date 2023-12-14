using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candys : InterectableObject
{
    public float HealAmount = 10f;

    public override void StartInteractions(GameObject owner, GameObject player)
    {
        Character character = owner.GetComponent<Character>();
        PlayerDamage playerDamage = player.GetComponent<PlayerDamage>();

        if (character.CurrentHp != character.MaxHp)
        {
            character.HealNb(HealAmount);
            playerDamage.UpdateHealthBar();
            Destroy(this.gameObject);
        }
    }
}
