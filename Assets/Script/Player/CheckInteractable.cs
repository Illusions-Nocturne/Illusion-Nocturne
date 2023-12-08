using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInteractable : MonoBehaviour
{
    [SerializeField]private float distance;
    [SerializeField]private GameObject obj;

    private Character character;
    private HealthBar healthBar;

    private float candyHealAmount = 10.0f;

    private void Start()
    {
        character = GetComponent<Character>();
        healthBar = GetComponent<HealthBar>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            CheckObject();
        }
    }
    void CheckObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            obj = hit.collider.gameObject;
            switch(obj.tag)
            {
                case "Door":
                    Destroy(obj);
                    break;
                case "Comforter":
                    SceneManager.LoadScene(SceneManager.loadedSceneCount - 1);
                    break;
                case "Candy":
                    character.HealNb(candyHealAmount);
                    healthBar.UpdateHealthBar(character.CurrentHp);
                    Destroy(obj);
                    break;
                default:
                    break;
            }
        }
    }
}
