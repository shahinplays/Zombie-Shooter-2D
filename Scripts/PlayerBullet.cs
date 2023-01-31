using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet: MonoBehaviour {
	
    public float bulletSpeed = 30f;
    public GameObject impactEffect;
    public Rigidbody2D rb;
    public bool isMissile;

    void Start()
    {      
        AudioManager.instance.PlaySFX(1);
    }

    void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyHealth = other.GetComponent<EnemyHealth>();

            int damageAmount = Random.Range(1, 15);
            bool isCriticalHit = Random.Range(0, 100) < 30;
            if (isCriticalHit) { damageAmount = 20; }
            if (isMissile) { damageAmount = 100; }
            enemyHealth.EnemyGetDamage(damageAmount);
            DamagePopUp.Create(transform.position, damageAmount, isCriticalHit);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        if (isMissile) { AudioManager.instance.PlaySFX(7); }
        
        
        Destroy(gameObject);


    }  

}


                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                