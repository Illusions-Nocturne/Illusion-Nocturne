using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    public static int CharacterChosen = 4;
    public GameObject BackGround1;
    public GameObject BackGround2;
    public GameObject BackGround3;
    public GameObject BackGround4;

    public Character[] character;

    public void Swordsman()
    {
        CharacterChosen = 0;
        if (character[CharacterChosen].IsAlive())
        {
            BackGround1.SetActive(true);
            BackGround2.SetActive(false);
            BackGround3.SetActive(false);
            BackGround4.SetActive(false);
            return;
        }
        BackGround1.SetActive(false);
    }

    public void Protector()
    {
        CharacterChosen = 1;
        if (character[CharacterChosen].IsAlive())
        {
            BackGround1.SetActive(false);
            BackGround2.SetActive(true);
            BackGround3.SetActive(false);
            BackGround4.SetActive(false);
            return;
        }
        BackGround2.SetActive(false);
    }

    public void Cleric()
    {
        CharacterChosen = 2;
        if (character[CharacterChosen].IsAlive())
        {
            BackGround1.SetActive(false);
            BackGround2.SetActive(false);
            BackGround3.SetActive(true);
            BackGround4.SetActive(false);
            return;
        }
        BackGround3.SetActive(false);
    }
    
    public void Mage()
    {
        CharacterChosen = 3;
        if (character[CharacterChosen].IsAlive())
        {
            BackGround1.SetActive(false);
            BackGround2.SetActive(false);
            BackGround3.SetActive(false);
            BackGround4.SetActive(true);
            return;
        }
        BackGround4.SetActive(false);
    }

    public void All()
    {
        CharacterChosen = 4;
        BackGround1.SetActive(false);
        BackGround2.SetActive(false);
        BackGround3.SetActive(false);
        BackGround4.SetActive(false);
    }
}
