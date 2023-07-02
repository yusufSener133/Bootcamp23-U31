using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform player;
    private bool isFlipped = true;

    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x && isFlipped)
        {
            FlipCharacter();
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        isFlipped = !isFlipped;
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}
