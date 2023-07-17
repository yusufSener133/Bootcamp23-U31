using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CAN
{
    public class EnemyHealth : MonoBehaviour
    {
        public int maxHealth = 100;
        public Animator enemy1_anim;
        public int currentHp;

        private void Start()
        {
            currentHp = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;
            enemy1_anim.SetTrigger("Hurt");

            if (currentHp <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            enemy1_anim.SetBool("IsDead", true);
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            //GetComponent<Collider2D>().enabled = false;
        }

        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}    