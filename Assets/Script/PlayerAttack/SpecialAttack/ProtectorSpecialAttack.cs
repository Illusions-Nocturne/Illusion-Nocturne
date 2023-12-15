using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectorSpecialAttack : SpecialAttack
{
    public int CancelHit = 1;
    public PlayerDamage PlayerDamage;
    public int IframesDelay = 3;

    public override bool StartSpecialAttack(GameObject owner)
    {
        StartCoroutine(cooldownActifCapacity());
        return true;
    }

    private IEnumerator cooldownActifCapacity()
    {
        PlayerDamage.SetCancelHit(true);
        yield return new WaitForSeconds(IframesDelay);
        PlayerDamage.SetCancelHit(false);
    }
}
