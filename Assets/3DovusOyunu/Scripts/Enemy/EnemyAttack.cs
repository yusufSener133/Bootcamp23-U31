using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CAN
{
    public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10; 
    float _timer = 2f;
    private bool attackCheck;
    private Transform player;
    
   // public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 2f;
    public LayerMask attackMask;

    public void Attack()
    {
        if (attackCheck && _timer >= 2)
        {
            _timer = 0f;
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            player = other.transform;
            attackCheck = true;
        }
        else
        {
            attackCheck = false;
            player = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
}