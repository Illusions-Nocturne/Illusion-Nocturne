using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDoor : MonoBehaviour
{
    public List<GameObject> Door;
    public List<GameObject> ennemies;
    public Transform parentEnnemy;
    private void Update()
    {
        if(parentEnnemy.childCount == 0)
        {
            DesactiveAllDoor();
        }
    }
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            ActiveAllDoor();
            ActiveEnemy();
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void ActiveEnemy()
    {
        if(ennemies.Count != 0)
        {
            for (int i = 0; i < ennemies.Count; i++)
            {
                ennemies[i].SetActive(true);
            }
        }
    }
    private void ActiveAllDoor()
    {
        foreach (GameObject door in Door)
        {
            door.SetActive(true);
            if (door.GetComponent<Doors>())
            {
                door.GetComponent<Doors>().canOpen = false;
            }
            if (door.GetComponent<SpecialDoors>())
            {
                door.GetComponent<SpecialDoors>().canOpen = false;
            }
        }
    }
    private void DesactiveAllDoor()
    {
        foreach (GameObject door in Door)
        {
            door.SetActive(false);
            if (door.GetComponent<Doors>())
            {
                door.GetComponent<Doors>().canOpen = true;
            }
            if (door.GetComponent<SpecialDoors>())
            {
                door.GetComponent<SpecialDoors>().canOpen = true;
            }
        }
    }
}
