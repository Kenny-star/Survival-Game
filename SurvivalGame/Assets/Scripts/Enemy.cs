using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject EnemyAI;
    public HealthBar EnemyhealthBar;
    public static bool isDestroyed = false;
    //internal Vector3 position;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        EnemyhealthBar.SetMaxHealth(maxHealth);

        
    }

    void Update()
    {

        if (Gun.isHit == true)
        {
            TakeDamage(10);
            Gun.setIsHit(false);
        }
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        EnemyhealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(EnemyAI);
        isDestroyed = true;
    }
}
