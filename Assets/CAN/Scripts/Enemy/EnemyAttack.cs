using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10; 
    float _timer = 1f;
    
   // public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 2f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        // pos += transform.right * attackOffset.x;
        // pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            Debug.Log("hasar verildi");
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
        
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other&& _timer >= 1)
        {
            Debug.Log("hasar verildi");
            _timer = 0f;
            other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
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