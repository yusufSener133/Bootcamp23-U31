using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Y
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Assignment")]
        private Animator _animator;
        [Header("Variable")]
        [SerializeField, Range(0, 1)] private float _speed = .3f;
        private Vector2 _movement;
        private float _vertical, _horizontal;
        private bool _stopGame = false;
        public bool StopGame { get => _stopGame; set { _stopGame = value; } }
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        private void Update()
        {
            if (!_stopGame)
                inputAssignment();
        }
        private void FixedUpdate()
        {
            if (!_stopGame)
                Movement();
        }
        void inputAssignment()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            _movement = new Vector2(_horizontal, _vertical);
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
        public bool PlayerSpeed() => Mathf.Abs(_horizontal) != 0 || Mathf.Abs(_vertical) != 0;
    }/**/
}
