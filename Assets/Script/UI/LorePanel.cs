using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class LoreTexte
{
    [TextArea] public string text = "";
    [Min(0)]   public int fontSize = 20;
}

public class LorePanel : MonoBehaviour
{
    [SerializeField] private List<LoreTexte> texte;

    [SerializeField] private float      beginTimer = 2f;

    [SerializeField] private Text       loreTexte;
    [SerializeField] private Image      loreBackground;
    [SerializeField] private GameObject canvas;

    [SerializeField] private UnityEvent endFadOutEvent;
    [SerializeField] private UnityEvent beginLorePanel;

    private bool isEnd = false;
    private int index = 0;

    private void Update()
    {
        if (!isEnd) { return; }

        if (Input.anyKeyDown)
        {
            if (index < texte.Count)
            {
                loreTexte.text = texte[index].text;
                loreTexte.fontSize = texte[index].fontSize;
                index++;
            }
            else
            {
                StartCoroutine(FadOutLore());
            }
        }
    }

    private void Start()
    {
        loreTexte.fontSize = texte[index].fontSize;
        loreTexte.text = texte[index].text;
        index++;
        Invoke(nameof(ActiveCanvas), beginTimer);
    }

    private void ActiveCanvas()
    {
        beginLorePanel?.Invoke();

        canvas.SetActive(true);
        isEnd = true;
    }

    private IEnumerator FadOutLore()
    {
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
