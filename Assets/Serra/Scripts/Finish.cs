using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
private Animator anim;
    private AudioSource finishSound;
    private bool levelCompleted = false;
    //[SerializeField] private Animator finish;
    // private enum MovementState {finish_anim, finish}
    
    // Start is called before the first frame update
    void Start()
    {
        finishSound=GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

if (collision.gameObject.name =="Player" && !levelCompleted)
{finishSound.Play();
levelCompleted = true;
anim.SetBool("finishbool", true);





Invoke("CompleteLevel", 2f);
}
 //void Update() {MovementState state;
 //if (collision.gameObject.name =="Player" && !levelCompleted)
//state=MovementState.finish;}



    }

    private void CompleteLevel(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
