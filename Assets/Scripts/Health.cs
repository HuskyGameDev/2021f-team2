using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; //at the beginning of the game, set currentHealth equal to maxHealth



    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void setHealth() //Passed no arguments, restores health to normal
    {
        currentHealth = maxHealth;
    }
    public void setHealth(int i)
    {
        currentHealth = i;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        CheckDeath();
    }
            

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckDeath()   //Called whenever a player takes damage.
    {

        Debug.Log("Player took damage! Current health is " + currentHealth + "!");//debug code obviously

        if(currentHealth <= 0)
        {
            //die die you zombie bastards
        }
    }
}
