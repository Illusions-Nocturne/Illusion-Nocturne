using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public BasicAttack[] BasicAttackCharacters;
    public SpecialAttack[] SpecialAttackCharacters;
    public Character[] characters;
    public CooldownBar cooldown;
    public MovePlayer playerMove;
    public bool OnUi;

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        foreach (var character in characters)
        {
            character.CurrentCD -= Time.deltaTime;
        }

        /*if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && characters[ChooseCharacter.CharacterChosen].CurrentCD < 0.001 && !OnUi && characters[ChooseCharacter.CharacterChosen].IsAlive() && Time.timeScale != 0.0f)
        {
            AudioManager.instance.PlaySong("BasicAttack");
        }*/
        
            if (characters[ChooseCharacter.CharacterChosen].CurrentCD > 0f || playerMove.InMovement || OnUi || !characters[ChooseCharacter.CharacterChosen].IsAlive())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.instance.PlaySong("BasicAttack");
            BasicAttackCharacters[ChooseCharacter.CharacterChosen].Attack();
            characters[ChooseCharacter.CharacterChosen].CurrentCD = characters[ChooseCharacter.CharacterChosen].CDBaseAttack;

            switch (ChooseCharacter.CharacterChosen)
            {
                case 0: cooldown.CooldownBarSlider1.maxValue = cooldown.SwordMan.CDBaseAttack; break;
                case 1: cooldown.CooldownBarSlider2.maxValue = cooldown.Protector.CDBaseAttack; break;
                case 2: cooldown.CooldownBarSlider3.maxValue = cooldown.Mage.CDBaseAttack; break;
                case 3: cooldown.CooldownBarSlider4.maxValue = cooldown.Cleric.CDBaseAttack; break;
            }
            cooldown.UpdateCooldownBar();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            bool complete = SpecialAttackCharacters[ChooseCharacter.CharacterChosen].StartSpecialAttack(SpecialAttackCharacters[ChooseCharacter.CharacterChosen].gameObject);

            if (!complete)
            {
                return;
            }
            characters[ChooseCharacter.CharacterChosen].CurrentCD = characters[ChooseCharacter.CharacterChosen].CDSpecialAttack;
            
            switch (ChooseCharacter.CharacterChosen)
            {
                case 0: cooldown.CooldownBarSlider1.maxValue = cooldown.SwordMan.CDSpecialAttack; break;
                case 1: cooldown.CooldownBarSlider2.maxValue = cooldown.Protector.CDSpecialAttack; break;
                case 2: cooldown.CooldownBarSlider3.maxValue = cooldown.Mage.CDSpecialAttack; break;
                case 3: cooldown.CooldownBarSlider4.maxValue = cooldown.Cleric.CDSpecialAttack; break;
            }
            cooldown.UpdateCooldownBar();
        }
    }

    public void SetOnUI(bool enable) => OnUi = enable;
}
