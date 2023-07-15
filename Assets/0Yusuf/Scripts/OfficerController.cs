using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Y
{
    public class OfficerController : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] PlayerMovement _player;
        [SerializeField] UIManager _uiManager;
        Animator _playerAnim;
        [Header("Variable")]
        [SerializeField] float _sound = 0;
        public float Sound { get => _sound; set { _sound = value; } }
        private void Awake()
        {
            _playerAnim = _player.GetComponentInChildren<Animator>();
        }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            if (_sound > 0)
                _sound--;
            StartCoroutine(Start());
        }
        private void Update()
        {
            if (_sound > 100)
            {
                LoseGame();
            }
        }

        void LoseGame()
        {
            GetComponent<Animator>().SetBool("Wake", true);
            //_player.StopGame = true;
            _player.enabled = false;
            //_playerAnim.SetBool("Right", false);
            //_playerAnim.SetBool("Left", false);
            //_playerAnim.SetBool("Up", false);
            //_playerAnim.SetBool("Down", false);
        }
        public void OfficerWakeUp()
        {
            _uiManager.LoseGame();
        }
    }/**/
}
