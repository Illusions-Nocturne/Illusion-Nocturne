using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDoor : MonoBehaviour
{
    public GameObject Door;
    public List<GameObject> ennemies;
    public Transform parentEnnemy;
    private void Update()
    {
        if(parentEnnemy.childCount == 0)
        {
            Door.tag = "Door";
        }
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            Door.SetActive(true);
            Door.tag = "Untagged";
            ActiveEnemy();
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void ActiveEnemy()
    {
        for(int i = 0; i < ennemies.Count; i++)
        {
            ennemies[i].SetActive(true);
        }
    }
}
