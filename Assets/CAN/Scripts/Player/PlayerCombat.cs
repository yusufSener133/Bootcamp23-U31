using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{
    public Animator player_Anim;
    public Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    private float attackRate = 2.0f;
    private float nextAttackTime = 0.0f;
    
    private void Start()
    {
        player_Anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            { 
                player_Anim.SetTrigger("Attack");
                //Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play an attack animation
       
        //Detect all enemies in rage of attack
        Collider2D[] detectedEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //damage them
        
        foreach (Collider2D enemy in detectedEnemies)
        { 
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}