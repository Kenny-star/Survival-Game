using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    public HealthBar playerhealthBar;
    private float cooldown = 0f;
    
    //internal Vector3 position;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerhealthBar.SetMaxHealth(maxHealth);

    }

    void Update()
    {
        if(ChasePlayer.playerTookDamage == true && Time.time >= cooldown)
        {
            cooldown = Time.time + 1f;
            TakeDamage(25);
            ChasePlayer.playerTookDamage = false;
        }
        
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        setCurrentHealth(currentHealth);
        playerhealthBar.SetHealth(getCurrentHealth());

        if (getCurrentHealth() <= 0)
        {
            ChasePlayer.lost = true;

        }
    }

    private void setCurrentHealth(int ch)
    {
        currentHealth = ch; 
    }

    private int getCurrentHealth()
    {
        return currentHealth;
    }

}
