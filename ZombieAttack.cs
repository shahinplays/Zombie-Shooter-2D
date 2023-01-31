using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public void ZombieAttackTrig()
    {
        int damageAmount = Random.Range(1, 15);
        bool isCriticalHit = Random.Range(0, 100) < 30;
        if (isCriticalHit) { damageAmount = 20; }
        PlayerHealth.instance.PlayerGetDamage(damageAmount);
        DamagePopUp.Create(transform.position, damageAmount, isCriticalHit);
    }
}
