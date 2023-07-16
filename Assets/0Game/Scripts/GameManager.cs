using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Emre
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject _startscreen, _game;
        public void GameStartButton()
        {
            _startscreen.SetActive(false);
            _game.SetActive(true);
        }
        public void QuitButton() => Application.Quit();
        public void SceneUpload(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
    }
}