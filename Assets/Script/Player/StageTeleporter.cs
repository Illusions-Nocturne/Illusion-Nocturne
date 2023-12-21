using UnityEngine;

public class StageTeleporter : MonoBehaviour
{
    [SerializeField] private int indexTeleport = 0;
    private void OnTriggerEnter(Collider other)
    {
        GameObject gHit = other.gameObject;
        if (gHit.TryGetComponent<Teleporter>(out var t))
        {
            t.TeleportToTransform(indexTeleport);
        }

        if (gHit.TryGetComponent<MovePlayer>(out var mp))
        {
            mp.StopMovement();
        }

        if (gHit.TryGetComponent<PlayerDamage>(out var p))
        {
            GameObject cleric = p.Cleric.gameObject;

            if (cleric.TryGetComponent<ClericSpecialAttack>(out var csa))
            {
                csa.NumberHealPerStage = 5;
            }
        }
    }
}