using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
namespace Y
{
    public class UIManager : MonoBehaviour
    {
        [Header("Assignment")]
        [SerializeField] OfficerController _officer;
        [Header("UI")]
        [SerializeField] GameObject _winPanel;
        [SerializeField] GameObject _LosePanel;
        [SerializeField] TMP_Text _soundText;
        [SerializeField] TMP_Text _scoreText;
        [SerializeField] TMP_Text _bestScoreText;
        [SerializeField] Image _soundImage;
        private void Update()
        {
            SoundController();
        }
        public void SoundController()
        {
            _soundText.text = _officer.Sound + "/100";
            _soundImage.fillAmount = Mathf.Lerp(_soundImage.fillAmount, _officer.Sound / 100, 0.1f);
        }
        public void WinGame()
        {
            _winPanel.SetActive(true);
            if (PlayerPrefs.GetFloat("BestScore") < GameManager.Instance.Timer)
                PlayerPrefs.SetFloat("BestScore", GameManager.Instance.Timer);
            _scoreText.text = $"Oyun Süresi: {(int)GameManager.Instance.Timer} sn";
            _bestScoreText.text = $"En Ýyi Süre: {(int)PlayerPrefs.GetFloat("BestScore")} sn";
        }
        public void LoseGame()
        {
            _LosePanel.SetActive(true);
        }
        public void RestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void QuitGameButton()
        {
            SceneManager.LoadScene(0);
        }



    }/**/
}
