using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comforter : InterectableObject
{
    public string SceneName = "MainScene";

    public override void StartInteractions(GameObject owner, GameObject player)
    {
        SceneManager.LoadScene(SceneName);
    }
}
