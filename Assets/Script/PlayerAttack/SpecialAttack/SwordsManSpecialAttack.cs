using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SwordsManSpecialAttack : SpecialAttack
{
    public float DamageMultiplier = 1.75f;
    public float Range = 3f;

    public override bool StartSpecialAttack(GameObject owner)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, Range))
        {
            GameObject eHit = hit.collider.gameObject;
            if (eHit.TryGetComponent<EnemyStat>(out var stat))
            {
                AudioManager.instance.PlaySong("HitEnnemis");
                var currentAttack = owner.GetComponent<Character>().CurrentAtk;
                stat.TakeDmg(currentAttack * DamageMultiplier);
                if (!stat.IsAlive())
                {
                    owner.GetComponent<Character>().AddExp(stat.MaxExp);
                    Destroy(eHit);
                }
            }
        }
        return true;
    }
}
