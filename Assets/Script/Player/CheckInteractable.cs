using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckInteractable : MonoBehaviour
{
    [SerializeField]private float distance;
    [SerializeField]private GameObject obj;
    
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
                    obj.SetActive(false);
                    break;
                case "Comforter":
                    SceneManager.LoadScene(SceneManager.loadedSceneCount - 1);
                    break;
                default: 
                    break;
            }
        }
    }
}
