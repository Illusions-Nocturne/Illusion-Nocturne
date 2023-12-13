using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LorePanel : MonoBehaviour
{
    [SerializeField] private Text  loreTexte;
    [SerializeField] private Image loreBackground;
    [SerializeField] private UnityEvent endFadOutEvent;

    private void Start()
    {
        StartCoroutine(FadOutLore());
    }

    private IEnumerator FadOutLore()
    {
        yield return new WaitForSeconds(2f);

        float counter = 0;
        while (counter < 1f)
        {
            loreBackground.color = new Color(
                loreBackground.color.r,
                loreBackground.color.g,
                loreBackground.color.b,
                loreBackground.color.a - Time.deltaTime
            );
            loreTexte.color = new Color(
                loreTexte.color.r,
                loreTexte.color.g,
                loreTexte.color.b,
                loreTexte.color.a - Time.deltaTime
            );
            counter += Time.deltaTime;
            yield return null;
        }

        if (endFadOutEvent != null)
            endFadOutEvent.Invoke();
    }
}
