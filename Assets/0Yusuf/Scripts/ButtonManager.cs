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
       
        public void StartGame()
        {
            _starting.SetActive(false);
            _game1.SetActive(true);
            Debug.Log(GameManager.Instance.Timer);
        }
        public void NextGame()
        {
            _game1.SetActive(false);
            _game2.SetActive(true);
        }
        public void LoseGame()
        {
            _game1.SetActive(true);
        }
    }/**/
}
