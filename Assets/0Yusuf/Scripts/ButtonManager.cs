using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Y
{
    public class ButtonManager : MonoBehaviour
    {

        [Header("Assignment")]
        [Header("Game")]
        [SerializeField] private GameObject _starting;
        [SerializeField] private GameObject _game1;
        [SerializeField] private GameObject _game2;
        [SerializeField] private TMP_Text _bestScore;
        private void Start()
        {
            
            _bestScore.text = "Best Score: " + (int)GameManager.Instance.Timer;
            Debug.Log(GameManager.Instance.Timer);
        }
        public void StartGame()
        {
            _starting.SetActive(false);
            _game1.SetActive(true);
            Debug.Log(GameManager.Instance.Timer);
        }
        public void WinGame()
        {
            if (PlayerPrefs.GetFloat("BestScore") < GameManager.Instance.Timer)
                PlayerPrefs.SetFloat("BestScore", GameManager.Instance.Timer);
            _game1.SetActive(false);
            _game2.SetActive(true);
        }
        public void LoseGame()
        {
            _game1.SetActive(true);
        }
    }
}
