using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public Weapon weapon;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerControler>().AddWeapon(weapon.gunNum);
            AudioManager.instance.PlaySFX(2);
            Destroy(gameObject);
        }
    }

}
