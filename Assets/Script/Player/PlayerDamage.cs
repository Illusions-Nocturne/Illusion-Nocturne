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
        healthBar.HealthBarSlider3.maxValue = Cleric.MaxHp;
        healthBar.HealthBarSlider4.maxValue = Mage.MaxHp;
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
        healthBar.UpdateHealthBar(SwordMan.CurrentHp);
        ChooseCharacter.CharacterChosen = 1;
        healthBar.UpdateHealthBar(Protector.CurrentHp);
        ChooseCharacter.CharacterChosen = 2;
        healthBar.UpdateHealthBar(Cleric.CurrentHp);
        ChooseCharacter.CharacterChosen = 3;
        healthBar.UpdateHealthBar(Mage.CurrentHp);
        ChooseCharacter.CharacterChosen = 0;
    }

    private void TakeDamageCurrentCharacter(int dmg)
    {
        switch (ChooseCharacter.CharacterChosen)
        {
            case 0: SwordMan.TakeDmg(dmg);  break;
            case 1: Protector.TakeDmg(dmg); break;
            case 2: Cleric.TakeDmg(dmg);    break;
            case 3: Mage.TakeDmg(dmg);      break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
            TakeDamageCurrentCharacter(trapDamage);
            UpdateHealthBar();
        }
    }
}
