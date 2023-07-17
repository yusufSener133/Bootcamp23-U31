using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakipece : MonoBehaviour
{
    public Transform Player1;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Player1.position);
        transform.position = Player1.position + offset;


    }
}
