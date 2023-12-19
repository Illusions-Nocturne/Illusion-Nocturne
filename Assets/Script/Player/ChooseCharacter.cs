using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    public static int CharacterChosen = 4;

    public void Swordsman()
    {
        CharacterChosen = 0;
    }

    public void Protector()
    {
        CharacterChosen = 1;
    }

    public void Cleric()
    {
        CharacterChosen = 2;
    }
    
    public void Mage()
    {
        CharacterChosen = 3;
    }

    public void All()
    {
        CharacterChosen = 4;
    }
}
