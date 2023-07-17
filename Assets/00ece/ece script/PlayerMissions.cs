using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissions : MonoBehaviour
{
    public GameObject CamNPC;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cam"))
        {
            PlayerPrefs.SetInt("Cam", 1);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("CamNPC"))
        {
           if(PlayerPrefs.GetInt("Cam") == 1)
            {

            }
            CamNPC.SetActive(true);
        }
        else
        {
            CamNPC.SetActive(false);
        }

    }
    
}

