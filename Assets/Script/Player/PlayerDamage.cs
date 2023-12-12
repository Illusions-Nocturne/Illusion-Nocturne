using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Character SwordMan;
    public Character Protector;
    public Character Cleric;
    public Character Mage;

    public HealthBar healthBar;
    [SerializeField] private int trapDamage;

    private void Awake()
    {        
        UpdateCharacterState();
        healthBar.HealthBarSlider1.maxValue = SwordMan.MaxHp;
        healthBar.HealthBarSlider2.maxValue = Protector.MaxHp;
        healthBar.HealthBarSlider3.maxValue = Mage.MaxHp;
        healthBar.HealthBarSlider4.maxValue = Cleric.MaxHp;
        UpdateHealthBar();
        ChooseCharacter.CharacterChosen = 0;
    }

    private void UpdateCharacterState()
    {
        SwordMan.CharacterStats();
        Protector.CharacterStats();
        Cleric.CharacterStats();
        Mage.CharacterStats();
    }

    private void UpdateHealthBar()
    {
        int currentCharacter = ChooseCharacter.CharacterChosen;

        ChooseCharacter.CharacterChosen = 0;
        healthBar.UpdateHealthBar(SwordMan.CurrentHp);

        ChooseCharacter.CharacterChosen = 1;
        healthBar.UpdateHealthBar(Protector.CurrentHp);

        ChooseCharacter.CharacterChosen = 2;
        healthBar.UpdateHealthBar(Mage.CurrentHp);

        ChooseCharacter.CharacterChosen = 3;
        healthBar.UpdateHealthBar(Cleric.CurrentHp);

        ChooseCharacter.CharacterChosen = currentCharacter;
    }

    public void TakeDamageCurrentCharacter(float dmg)
    {
        switch (ChooseCharacter.CharacterChosen)
        {
            case 0: SwordMan.TakeDmg(dmg);  break;
            case 1: Protector.TakeDmg(dmg); break;
            case 2: Mage.TakeDmg(dmg);      break;
            case 3: Cleric.TakeDmg(dmg);    break;
        }
        UpdateHealthBar();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
            TakeDamageCurrentCharacter(trapDamage);
        }
    }
}
