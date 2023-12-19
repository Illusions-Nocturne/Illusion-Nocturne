using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof (FakeComforterAttack))]
public class FakeComforter : MonoBehaviour
{
    private Coroutine detectPlayerCoroutine;
    private WaitForSeconds detectPlayerDelay = new WaitForSeconds(.1f);
    private Animator animator;
    private FakeComforterAttack attack;

    private string StartTransitionTrigger = "startTransition";

    public float DetectPlayerRange = 4.5f;
    public bool IsAwake { get; private set; } = false;

    public UnityEvent OnFakeComforterAwake;

    private void Start()
    {
        detectPlayerCoroutine = StartCoroutine(DetectPlayer());
        animator = GetComponent<Animator>();
    }

    public void TransitionIdleToAwake()
    {
        animator.SetTrigger(StartTransitionTrigger);

        if (OnFakeComforterAwake != null)
            OnFakeComforterAwake.Invoke();
    }
    public void SetIsAwake()
    {
        StopCoroutine(detectPlayerCoroutine);
        IsAwake = true;

        attack.StartAttackPlayer();
    }

    private IEnumerator DetectPlayer()
    {
        while (true) 
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, DetectPlayerRange);
            foreach (var item in colliders)
            {
                GameObject gHit = item.gameObject;
                if (gHit.CompareTag("Player"))
                {
                    TransitionIdleToAwake();
                    StopCoroutine(detectPlayerCoroutine);
                }
            }

            yield return detectPlayerDelay;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 1f, 1f, .3f);
        Gizmos.DrawSphere(transform.position, DetectPlayerRange);
    }
}
