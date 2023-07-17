using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CamCollect : MonoBehaviour
{
    bool cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cam"))
        {
            Destroy(collision.gameObject);
            cam = true;
            
        }

        if (collision.gameObject.CompareTag("door") && cam)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    
}
