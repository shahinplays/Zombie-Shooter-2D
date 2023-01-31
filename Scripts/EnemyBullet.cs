using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform player;
    private Vector2 moveDirection;
    public Rigidbody2D rb;

    public float speed = 20f;
    public GameObject impactEffect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        AudioManager.instance.PlaySFX(5);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //var playerHealth = other.GetComponent<PlayerHealth>();

            int damageAmount = Random.Range(1, 10);
            bool isCriticalHit = Random.Range(0, 100) < 30;
            if (isCriticalHit) { damageAmount = 15; }
            PlayerHealth.instance.PlayerGetDamage(damageAmount);
            DamagePopUp.Create(transform.position, damageAmount, isCriticalHit);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
