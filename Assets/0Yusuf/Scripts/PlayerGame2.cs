using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Y
{
    public class PlayerGame2 : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] OfficerController _officer;
        [SerializeField] UIManager _uiManager;
        PlayerMovement _player;
        Animator _playerAnim;
        [Header("Variable")]
        [SerializeField] private float _waitingTimeTrap = 3f;
        [SerializeField] private float _addSoundTrap = 10f;
        [SerializeField] private float _addSoundMovement = 3f;
        private float _timer = 1f;
        private float _timer2 = 3f;

        private void Awake()
        {
            _player = GetComponent<PlayerMovement>();
            _playerAnim = GetComponent<Animator>();
        }
        private void Update()
        {
            _timer += Time.deltaTime;
            _timer2 += Time.deltaTime;
            if (_player.PlayerSpeed() && _timer >= 1f)
            {
                _officer.Sound += _addSoundMovement;
                _timer = 0;
            }

        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Door") && Input.GetKeyDown(KeyCode.E))
            {
                _uiManager.WinGame();
                _player.StopGame = true;
                _playerAnim.SetBool("Right", false);
                _playerAnim.SetBool("Left", false);
                _playerAnim.SetBool("Up", false);
                _playerAnim.SetBool("Down", false);
            }
            if (collision.CompareTag("Trap") && _timer2 >= _waitingTimeTrap)
            {
                _officer.Sound += _addSoundTrap;
                _timer2 = 0;
            }
        }
    }/**/
}

