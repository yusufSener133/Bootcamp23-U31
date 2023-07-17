using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] GameObject camImage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log(collision.gameObject.tag + "temas etti");
            camImage.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
