using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position + transform.forward * attackOffset.z;
        pos += transform.up * attackOffset.y;

        Collider[] colliders = Physics.OverlapSphere(pos, attackRange, attackMask);
        foreach (Collider collider in colliders)
        {
            PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enragedAttackDamage);
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position + transform.forward * attackOffset.z;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}