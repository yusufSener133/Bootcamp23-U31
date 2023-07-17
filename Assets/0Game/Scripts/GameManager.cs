using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Emre
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject _startscreen, _game;
        private void Start()
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (PlayerPrefs.GetFloat("CheckScene") == 1)
            {
                _startscreen.SetActive(false);
                _game.SetActive(true);
            }
        }
        public void GameStartButton()
        {
            _startscreen.SetActive(false);
            _game.SetActive(true);
            PlayerPrefs.SetFloat("CheckScene", 1);
        }
        public void QuitButton()
        {
            PlayerPrefs.SetFloat("CheckScene", 0);
            Application.Quit();
        }
        public void SceneUpload(int sceneIndex)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}