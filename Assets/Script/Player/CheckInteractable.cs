using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInteractable : MonoBehaviour
{
    [SerializeField]private float distance;
    private MovePlayer playerMove;

    public Character[] Character;

    private void Start()
    {
        playerMove = GetComponent<MovePlayer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            CheckObject();
        }
    }
    void CheckObject()
    {
        Character c = Character[ChooseCharacter.CharacterChosen];
        if (!c.IsAlive() || playerMove.InMovement)
            return;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            GameObject obj = hit.collider.gameObject;

            if (obj.TryGetComponent<InterectableObject>(out var o))
            {
                o.StartInteractions(c.gameObject, this.gameObject);
            }
        }
    }
}
