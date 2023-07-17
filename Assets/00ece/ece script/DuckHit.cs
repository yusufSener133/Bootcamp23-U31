using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Z eksenini sýfýrla (2D oyun olduðu için)


            Ray2D ray = new Ray2D(mousePosition, Vector2.zero);

            // Raycast ile týklama noktasýndaki objeyi algýla
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Algýlanan obje varsa
            if (hit.collider.gameObject.CompareTag("ordek"))
            {
                Debug.Log("Týklanan obje: " + hit.collider.gameObject.name);
            }
        }
    }




    public Animator OrdekAnim;

    public void OynatVurulmaAnimasyonu()
    {
        OrdekAnim.SetTrigger("Hasar");
    }
}