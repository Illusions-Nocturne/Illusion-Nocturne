using UnityEngine;

public class Comforter : InterectableObject
{
   public override void StartInteractions(GameObject owner, GameObject player)
    {
        UiVictoryDefeat.doudou = true;
        AudioManager.instance.PlaySong("SoundWin");
    }
}
