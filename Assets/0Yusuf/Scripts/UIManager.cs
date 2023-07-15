using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Y
{
    public class UIManager : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] GameObject _winPanel;
        [SerializeField] GameObject _LosePanel;
        [Header("Variable")]
        [SerializeField] float _deger;

        public void WinGame()
        {
            _winPanel.SetActive(true);
        }
        public void LoseGame()
        {
            _LosePanel.SetActive(true);
        }

        public void RestartButton()
        {

        }
        public void MainMenuButton()
        {

        }













    }/**/
}
