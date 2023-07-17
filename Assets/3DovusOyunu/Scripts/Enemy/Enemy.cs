using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CAN
{
    
public class Enemy : MonoBehaviour
{
    public Transform player;
    private bool isFlipped = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    public void LookAtPlayer()
    {
        if (transform.position.x > player.position.x && isFlipped)
        {
            FlipCharacter(2);
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            FlipCharacter(-2);
        }
    }

    private void FlipCharacter(float num)
    {
        isFlipped = !isFlipped;
        Vector3 scale = transform.localScale;
        scale.x = num;
        transform.localScale = scale;
    }
}
}