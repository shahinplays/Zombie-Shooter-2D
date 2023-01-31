using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxhealth = 100;
    private int currentHealth;
    public GameObject HitEffect, DeathEffects, coinDrop;

    void Start()
    {
        currentHealth = maxhealth;
    }


    public void EnemyGetDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(HitEffect, transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {
            Instantiate(DeathEffects, transform.position, Quaternion.identity);
            Instantiate(coinDrop, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
