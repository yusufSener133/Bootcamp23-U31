using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Y
{
    public class PlayerGame1 : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] private GameObject _doorPanel;
        [SerializeField] private GameObject _doorLock;
        private void Update()
        {
            ForceDoor();
        }
        void ForceDoor()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                GetComponentInChildren<SpriteRenderer>().enabled = false;
                _doorLock.SetActive(true);
            }
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Door"))
                _doorPanel.SetActive(true);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Door"))
                _doorPanel.SetActive(false);
        }
    }/**/
}