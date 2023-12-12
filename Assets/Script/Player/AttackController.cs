using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public BasicAttack[] BasicAttackCharacters;
    public SpecialAttack[] SpecialAttackCharacters;
    public Character[] characters;

    public MovePlayer playerMove;

    private void Update()
    {
        characters[ChooseCharacter.CharacterChosen].CurrentCD -= Time.deltaTime;

        if (characters[ChooseCharacter.CharacterChosen].CurrentCD > 0f || playerMove.InMovement)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            BasicAttackCharacters[ChooseCharacter.CharacterChosen].Attack();
            characters[ChooseCharacter.CharacterChosen].CurrentCD = characters[ChooseCharacter.CharacterChosen].CDBaseAttack;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SpecialAttackCharacters[ChooseCharacter.CharacterChosen].StartSpecialAttack(SpecialAttackCharacters[ChooseCharacter.CharacterChosen].gameObject);
            characters[ChooseCharacter.CharacterChosen].CurrentCD = characters[ChooseCharacter.CharacterChosen].CDSpecialAttack;
        }
    }
}
