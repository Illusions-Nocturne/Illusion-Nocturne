using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Character character;
    public HealthBar healthBar;
    // Start is called before the first frame update
    private void Awake()
    {
        character = GetComponent<Character>();
        healthBar = GetComponent<HealthBar>();
    }
    void Start()
    {       
        character.CharacterStats();
        healthBar.HealthBarSlider.maxValue = character.MaxHp;
        healthBar.UpdateHealthBar(character.MaxHp);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            character.TakeDmg(50);
            healthBar.UpdateHealthBar(character.CurrentHp);
        }
    }
}
