using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Y
{
    public class OfficerController : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] UIManager _uiManager;
        [Header("Variable")]
        [SerializeField] float _sound = 0;
        public float Sound { get => _sound; set { _sound = value; } }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            if (_sound > 100)
                LoseGame();
            else if (_sound > 0)
            {
                _sound--;
                StartCoroutine(Start());
            }
        }
        void LoseGame() => GetComponent<Animator>().SetBool("Wake", true);
        public void OfficerWakeUp() => _uiManager.LoseGame();
    }/**/
}
