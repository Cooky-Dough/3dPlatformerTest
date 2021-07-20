using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

namespace ThreeDeePlatformerTest.Scripts
{
    public class GameOverScript : MonoBehaviour
    {
        public static bool IsGameOver { get; set; }

        private Image _gameOverImage;
        private Text _gameOverText;

        private Button _restartButton;
        private Button _exitGameButton;
        private Text _restartButtonText;
        private Text _exitGameText;

        // Start is called before the first frame update
        void Start()
        {
            IsGameOver = false;
            _gameOverImage = GetComponent<Image>();
            _gameOverText = _gameOverImage.GetComponentInChildren<Text>();
            _restartButton = _gameOverImage.GetComponentInChildren<Button>();
            _restartButtonText = _restartButton.GetComponentInChildren<Text>();
            _exitGameButton = _gameOverImage.GetComponentsInChildren<Button>().FirstOrDefault(x => x.name == "ExitGame");
            _exitGameText = _exitGameButton.GetComponentInChildren<Text>();
        }

        public void RestartButton()
        {
            Debug.Log("Restart");
            SceneManager.LoadScene("SampleScene");
        }

        public void ExitGameButton()
        {
            Application.Quit();
        }

        void Update()
        {
            _gameOverText.gameObject.SetActive(IsGameOver);
            _gameOverImage.enabled = IsGameOver;
            _restartButton.gameObject.SetActive(IsGameOver);
            _restartButtonText.gameObject.SetActive(IsGameOver);
            _exitGameButton.gameObject.SetActive(IsGameOver);
            _exitGameText.gameObject.SetActive(IsGameOver);
        }
    }
}