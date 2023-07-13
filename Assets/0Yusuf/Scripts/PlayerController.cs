using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] private GameObject _doorPanel;
        [SerializeField] private GameObject _doorLock;
        private Animator _animator;
        [Header("Variable")]
        [SerializeField, Range(0, 1)] private float _speed = .3f;
        private Vector2 _movement;
        private float _vertical, _horizontal;
        private bool _stop = false;
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        private void Update()
        {
            if (!_stop)
                inputAssignment();
            ForceDoor();
        }
        private void FixedUpdate()
        {
            if (!_stop)
                Movement();
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
        void inputAssignment()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _movement = new Vector2(_horizontal, _vertical);
        }
        void ForceDoor()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _stop = true;
                _doorLock.SetActive(true);
            }
        }
        void Movement()
        {
            if (_movement != Vector2.zero)
                transform.Translate(_movement * _speed);
            AnimControls();
        }
        void AnimControls()
        {
            _animator.SetBool("Right", _horizontal > 0);
            _animator.SetBool("Left", _horizontal < 0);
            _animator.SetBool("Up", _vertical > 0);
            _animator.SetBool("Down", _vertical < 0);
        }
    }/**/
}