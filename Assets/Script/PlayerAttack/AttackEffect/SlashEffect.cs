using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlashEffect : AttackEffect
{
    public List<Sprite> sprite;
    private Image img;
    [SerializeField] private float time;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public override void BeginEffect(GameObject owner)
    {
        StartCoroutine(Slash());
    }

    IEnumerator Slash()
    {
        for(int i  = 0; i < sprite.Count; i++)
        {
            img.sprite = sprite[i];
            yield return new WaitForSeconds(time);
        }
    }
}
