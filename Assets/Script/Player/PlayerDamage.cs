using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Character character;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.HealthBarSlider.maxValue = character.PercentHp;
        healthBar.UpdateHealthBar(character.PercentHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            character.takeDMG(50);
            healthBar.UpdateHealthBar(character.PercentHp);
        }
    }
}
