using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Collide : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("UI"))
        {

            var a = other.gameObject.transform.GetChild(0).gameObject;

            a.SetActive(true);
            
            
            //other. GetComponentInChildren<GameObject>().gameObject.SetActive(true);
            

        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("UI"))
        {

            var a = other.gameObject.transform.GetChild(0).gameObject;

            a.SetActive(false);

        }
    }
  
}
