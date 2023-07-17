using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public DialogueTrigger trigger;
    private bool isDialoguePlayed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDialoguePlayed)
        {
            trigger.StartDialogue();
            isDialoguePlayed = true;
        }
    }
}
