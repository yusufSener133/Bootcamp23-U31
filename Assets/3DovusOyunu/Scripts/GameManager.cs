using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CAN
{
    public class GameManager : MonoBehaviour
    {
        private bool isGameActive;

        public GameObject startUI;
        public GameObject loseUI;
        public GameObject winUI;

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
        }

        public void ButtonFunction()
        {
            startUI.gameObject.SetActive(false);
            isGameActive = true;
            Time.timeScale = 1;

        }
        public bool StartGame()
        {
            return true;
        }

        public void GameOver()
        {

            loseUI.gameObject.SetActive(true);
            isGameActive = false;
            Time.timeScale = 0;

        }

        public void WinTrigger()
        {
            isGameActive = false;
            Time.timeScale = 0;
            winUI.gameObject.SetActive(true);
        }

        public void ReturnMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void RestartButton()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}