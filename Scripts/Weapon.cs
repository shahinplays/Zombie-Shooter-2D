using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //player shooting
    public GameObject bullet;
    public Transform firePoint;
    public GameObject gunfireSmoke;
    public Animator muzzleFlashAnim;
    public float fireRate = 0.3f;
    [HideInInspector] public float nextFire;

    public int gunNum;







}
