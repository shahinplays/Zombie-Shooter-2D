using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinPickUpEffect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {            
            Instantiate(coinPickUpEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
