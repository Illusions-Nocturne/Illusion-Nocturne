using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public BasicAttack[] BasicAttackCharacters;
    public SpecialAttack[] SpecialAttackCharacters;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BasicAttackCharacters[ChooseCharacter.CharacterChosen].Attack();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SpecialAttackCharacters[ChooseCharacter.CharacterChosen].StartSpecialAttack(SpecialAttackCharacters[ChooseCharacter.CharacterChosen].gameObject);
        }
    }
}
