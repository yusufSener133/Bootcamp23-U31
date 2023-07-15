using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Y
{
    public class AnchorMotor : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] TMP_Text _remainderText;
        [SerializeField] Animator _lockBase;
        [SerializeField] Transform _dot;
        [SerializeField] List<Image> _heartsImage;
        [SerializeField] GameObject _WinPanels;
        [SerializeField] GameObject _LosePanels;
        private Transform _anchor;
        private GameObject _currentDot;
        [Header("Variable")]
        [SerializeField, Range(0, 10)] private float _speed = 5f;
        [SerializeField, Range(0, 10)] private int _remainderDots = 10;
        [SerializeField, Range(0, 3)] private int _health = 3;
        private Vector3 _startPosAnchor = new Vector3(0, 2.8f, 0);
        private int _direction = 1;
        private bool _isRunning = true;
        private void Awake()
        {
            _anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        }
        void Update()
        {
            if (_isRunning)
                RotatePaddle();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Dot"))
                _currentDot = collision.gameObject;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Dot"))
                _currentDot = null;
        }
        void RotatePaddle()
        {
            transform.RotateAround(_anchor.position, Vector3.forward, _speed * Time.deltaTime * _direction);
            ChangeDirection();
            GamePoint();
        }
        void ChangeDirection()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                _direction *= -1;
        }
        void GamePoint()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (_remainderDots <= 0)
                {
                    _isRunning = false;
                    WinLockGame();
                    return;
                }
                if (_currentDot != null)
                {
                    _remainderDots -= 1;
                    if (_health < 3)
                    {
                        _health++;
                        HeartControl();
                    }
                    _dot.RotateAround(_anchor.position, Vector3.forward, Random.Range(0, 360));
                    transform.position = _startPosAnchor;
                    transform.localRotation = Quaternion.identity;
                    _remainderText.text = _remainderDots + "";
                }
                else
                {
                    if (_health <= 0)
                    {
                        _isRunning = false;
                        LoseLockGame();
                        return;
                    }
                    _health -= 1;
                    HeartControl();

                    _lockBase.Play("LockLoseAnim");
                }
            }
        }
        void HeartControl()
        {
            switch (_health)
            {
                case 3:
                    _heartsImage[2].gameObject.SetActive(true);
                    break;
                case 2:
                    _heartsImage[1].gameObject.SetActive(true);
                    _heartsImage[2].gameObject.SetActive(false);
                    break;
                case 1:
                    _heartsImage[0].gameObject.SetActive(true);
                    _heartsImage[1].gameObject.SetActive(false);
                    break;
                case 0:
                    _heartsImage[0].gameObject.SetActive(false);
                    break;

            }
        }
        void WinLockGame()
        {
            _WinPanels.SetActive(true);
        }
        void LoseLockGame()
        {
            _LosePanels.SetActive(true);
        }
    }/**/
}