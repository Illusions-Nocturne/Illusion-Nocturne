using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Comforter : InterectableObject
{
   public override void StartInteractions(GameObject owner, GameObject player)
    {
        UiVictoryDefeat.doudou = true;
    }
}
