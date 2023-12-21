using UnityEngine;

public class Comforter : InterectableObject
{
   public override void StartInteractions(GameObject owner, GameObject player)
    {
        Time.timeScale = 0f;
        UiVictoryDefeat.doudou = true;
        AudioManager.instance.PlaySong("SoundWin");
    }
}
