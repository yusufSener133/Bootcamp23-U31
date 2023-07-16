using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace S
{
    public class PlayerLife : MonoBehaviour
    {
        private Animator anim;
        private Rigidbody2D rb;
        [SerializeField] private AudioSource deathsoundSoundEffect;
        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }
        private void OnCollisionEnter2D(Collision2D collision)

        {
            if (collision.gameObject.CompareTag("tuzak"))
            {
                Die();
            }

        }
        private void Die()
        {
            deathsoundSoundEffect.Play();
            anim.SetTrigger("death");
            rb.bodyType = RigidbodyType2D.Static;
        }
        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}