using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;
    public Animator anim;

    //Attacking
    public float attackRate = 1f;
    private float nextAttack;

    public GameObject projectile;

    public Transform firePoint;
    public bool isZombie, isSoilder;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (player == null) { return; }

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }



    void FixedUpdate()
    {
        if (player == null) { return; }

        if (Vector2.Distance(transform.position, player.position) >= agent.stoppingDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            AttackPlayer();
        }
        
        RotateToPlayer();

    }



    private void AttackPlayer()
    {

        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + attackRate;
            // Attack Code Here
            if (isSoilder)
            {
                if(player.gameObject.activeInHierarchy)
                {
                    Instantiate(projectile, firePoint.position, firePoint.rotation);
                }
                
            }
            else if (isZombie)
            {
                if (player == null) { return; }
                anim.SetTrigger("Attack");
            }
        }

    }





    private void RotateToPlayer()
    {
        Vector3 vectorToTarget = new Vector3(player.position.x + 1.25f, player.position.y - 1.25f, 0) - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
    }









}
