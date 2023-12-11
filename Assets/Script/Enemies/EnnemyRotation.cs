using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyRotation : MonoBehaviour
{
    private GameObject player;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.transform.rotation;
    }
}
