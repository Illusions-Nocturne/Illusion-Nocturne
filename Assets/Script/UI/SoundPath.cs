using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPath : MonoBehaviour
{
    public static int IndexSound;

    public static void PlaySongPath()
    {
        if (IndexSound == 4)
        {
            IndexSound = 0;
        }

        switch (IndexSound)
        {
            case 0: AudioManager.instance.PlaySong("Path1"); break;
            case 1: AudioManager.instance.PlaySong("Path2"); break;
            case 2: AudioManager.instance.PlaySong("Path3"); break;
            case 3: AudioManager.instance.PlaySong("Path4"); break;

        }
    }


}
