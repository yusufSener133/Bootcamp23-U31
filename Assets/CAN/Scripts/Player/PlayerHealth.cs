using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CAN
{
    public class PlayerHealth : MonoBehaviour
{
    public GameManager _gameManager;
    public int health = 100;

    public Animator pl_anim;

    public void TakeDamage(int damage)
    {
        health -= damage;
        // StartCoroutine(DamageAnimation());

        if (health <= 0)
        {
            _gameManager.GameOver();
        }
    }



    // IEnumerator DamageAnimation()
    // {
    //     SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();
    //
    //     for (int i = 0; i < 3; i++)
    //     {
    //         foreach (SpriteRenderer sr in srs)
    //         {
    //             Color c = sr.color;
    //             c.a = 0;
    //             sr.color = c;
    //         }
    //
    //         yield return new WaitForSeconds(.1f);
    //
    //         foreach (SpriteRenderer sr in srs)
    //         {
    //             Color c = sr.color;
    //             c.a = 1;
    //             sr.color = c;
    //         }
    //
    //         yield return new WaitForSeconds(.1f);
    //     }
    // }
}
}