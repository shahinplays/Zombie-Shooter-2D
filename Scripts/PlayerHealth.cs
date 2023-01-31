using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int maxhealth = 100;
    [HideInInspector] public int currentHealth;
    public GameObject deathEffect, hitEffect;

    private float damageInvinceLength = 1f;
    private float invinceCount;
    public SpriteRenderer playerBody;

    public TMP_Text healthText;

    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        currentHealth = maxhealth;
        healthText.text = currentHealth.ToString();
    }


    void Update()
    {
        if (invinceCount > 0)
        {
            invinceCount -= Time.deltaTime;
            if (invinceCount <= 0)
            {
                playerBody.color = Color.white;
            }
        }
    }




    public void PlayerGetDamage(int damage)
    {
        if (invinceCount <= 0)
        {
            currentHealth -= damage;
            AudioManager.instance.PlaySFX(0);
            invinceCount = damageInvinceLength;

            playerBody.color = Color.red;

            Instantiate(hitEffect, playerBody.transform.position, transform.rotation);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Instantiate(deathEffect, playerBody.transform.position, transform.rotation);
                PlayerControler.instance.gameObject.SetActive(false);
                GameManager.instance.joystickPanal.SetActive(false);
                GameManager.instance.gameOverPanal.SetActive(true);
                AudioManager.instance.PlayGameOver();

            }

            healthText.text = currentHealth.ToString();
        }
    }



    public void MakeInvincible(float length)
    {
        invinceCount = length;
        playerBody.color = new Color(1f, 1f, 1f, 0.5f);
    }




}
