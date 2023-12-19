using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCreak : MonoBehaviour
{
    private int v;

    public void Start()
    {
        StartCoroutine(EPlaySong());
    }
    IEnumerator EPlaySong()
    {
        yield return new WaitForSeconds(60);
        AudioManager.instance.PlaySong("WoodCreak");
        StartCoroutine(EPlaySong());
    }

}
