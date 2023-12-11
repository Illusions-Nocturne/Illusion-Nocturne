using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheatCodeConsole : MonoBehaviour
{
    [SerializeField] private List<DictionaryElement<string, UnityEvent>> CheatCodes;

    [SerializeField] private GameObject inputField;
    [SerializeField] private InputField field;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            setVisibleCheatCodeConsole(!inputField.activeSelf);
    }

    private void setVisibleCheatCodeConsole(bool visible)
    {
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
                break;
            }
        }
    }

    public void Print(string txt)
    {
        Debug.Log(txt);
    }
}
