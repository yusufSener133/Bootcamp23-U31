using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace S
{
    public class StartMenu : MonoBehaviour
    {
        public void StartGame(int nextSceneBuildIndex)
        {
            SceneManager.LoadScene(nextSceneBuildIndex);
        }

    }
}