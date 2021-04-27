using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    private float maxHealth;

    public bool allowShot = true;
    private bool checkHealing = true;
    

    private void Awake()
    {
        maxHealth = health;
    }

    private void Start()
    {
        StartCoroutine(Regen());
    }

    public void TakeDamage(float damage)
    {
        
       // if(allowShot)
        //{
            allowShot = false;
            health = health - damage;
            if (health <= 0f)
            {

                Die();
            }
        //}

        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        //CoverAlly(); 
    }

    public float getHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    IEnumerator Regen()
    {
        //store health 
        //check health against another value after 3 seconds 
        //then heal 10 per second

        while(checkHealing)
        {
            float oldHealth = health;
            yield return new WaitForSecondsRealtime(2f);
            if (health >= oldHealth)
            {
                if (health < maxHealth)
                {
                    health += 10;
                }
                else if (health >= maxHealth)
                {
                    health = maxHealth;
                }
            }

            yield return null;
        }


    }

}
