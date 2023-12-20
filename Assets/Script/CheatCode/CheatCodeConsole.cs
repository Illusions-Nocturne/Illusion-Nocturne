using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheatCodeConsole : MonoBehaviour
{
    private WaitForSeconds unValidCommandDelay = new WaitForSeconds(1f);
    private MovePlayer move;

    [SerializeField] private List<DictionaryElement<string, UnityEvent>> CheatCodes;

    [SerializeField] private GameObject inputField;
    [SerializeField] private InputField field;

    [Header("Shake")]
    [SerializeField] private RectTransform elementToShake;
    [SerializeField, Min(0)] private float shakePower = 100;
    [SerializeField, Min(0)] private int numberShake = 100;

    [Header("Commande text")]
    [SerializeField] private Text  commandeText;
    [SerializeField] private Color unValidShakeColor = Color.red;
    [SerializeField] private Color baseTextColor = Color.black;

    private void Start()
    {
        move = GetComponent<MovePlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            setVisibleCheatCodeConsole(!inputField.activeSelf);
    }

    private void setVisibleCheatCodeConsole(bool visible)
    {
        move.InMovement = visible;
        inputField.SetActive(visible);
    }
    public void SubmitCheatCode(string code)
    {
        foreach (var item in CheatCodes)
        {
            if (item.Key == code)
            {
                item.Value.Invoke();
                field.text = "";
                return;
            }
        }

        StartCoroutine(UnValidCode());
        StartCoroutine(ShakeCommandeField());
    }

    private IEnumerator UnValidCode()
    {
        field.readOnly = true;
        commandeText.color = unValidShakeColor;
        field.text = "Commande invalide";
        yield return unValidCommandDelay;
        field.text = "";
        commandeText.color = baseTextColor;
        field.readOnly = false;
    }

    private IEnumerator ShakeCommandeField()
    {
        for (int i = 0; i < numberShake; i++)
        {
            Vector3 rot = new Vector3(
              elementToShake.eulerAngles.x,
              elementToShake.eulerAngles.y,
              Mathf.Cos(Time.time * shakePower)
            );
            elementToShake.eulerAngles = rot;
            yield return null;
        }

        elementToShake.eulerAngles = Vector3.zero;
    }
}
