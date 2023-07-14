using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    private int meyve = 0;
    [SerializeField] private Text MeyveText;
    [SerializeField] private AudioSource collectsoundSounEffect;
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("meyve")) {
            collectsoundSounEffect.Play();
            
            Destroy (collision.gameObject);
        meyve++;
        MeyveText.text = "Yiyecek: " + meyve;
      
        
    }
} }
