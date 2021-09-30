using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

// TODO: Rename file.
namespace ThreeDeePlatformerTest.Scripts
{
    public class ScreenScript : MonoBehaviour
    {
        public static bool IsGameOver { get; set; }
        public static bool IsPaused { get; set; }

        private Image _gameOverImage;
        private Text _gameOverText;
        private Button _restartButton;
        private Button _exitGameButton;
        private Text _restartButtonText;
        private Text _exitGameText;

        private Image _pauseImage;
        private Text _pauseText;
        private Button _pauseRestartButton;
        private Button _pauseExitGameButton;
        private Text _pauseRestartButtonText;
        private Text _pauseExitGameText;

        // Start is called before the first frame update
        void Start()
        {
            IsGameOver = false;
            IsPaused = false;
            var canvas = GetComponent<Canvas>();

            _gameOverImage = canvas.GetComponentsInChildren<Image>().First(x => x.name == "GameOverImage");
            _gameOverText = _gameOverImage.GetComponentInChildren<Text>();
            _restartButton = _gameOverImage.GetComponentInChildren<Button>();
            _restartButtonText = _restartButton.GetComponentInChildren<Text>();
            _exitGameButton = _gameOverImage.GetComponentsInChildren<Button>().FirstOrDefault(x => x.name == "ExitGame");
            _exitGameText = _exitGameButton.GetComponentInChildren<Text>();
            _restartButton.onClick.AddListener(RestartButton);
            _exitGameButton.onClick.AddListener(ExitGameButton);

            _pauseImage = canvas.GetComponentsInChildren<Image>().First(x => x.name == "PauseImage");
            _pauseText = _pauseImage.GetComponentInChildren<Text>();
            _pauseRestartButton = _pauseImage.GetComponentInChildren<Button>();
            _pauseRestartButtonText = _pauseRestartButton.GetComponentInChildren<Text>();
            _pauseExitGameButton = _pauseImage.GetComponentsInChildren<Button>().FirstOrDefault(x => x.name == "ExitGame");
            _pauseExitGameText = _pauseExitGameButton.GetComponentInChildren<Text>();
            _pauseRestartButton.onClick.AddListener(RestartButton);
            _pauseExitGameButton.onClick.AddListener(ExitGameButton);
        }

        public void RestartButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ExitGameButton()
        {
            Application.Quit();
        }

        void Update()
        {
            if (!IsPaused)
            {
                SetGameOverScreen();
            }
            if (IsGameOver)
            {
                return;
            }
            if (Input.GetButtonDown("Cancel"))
            {
                IsPaused = !IsPaused;
            }
            SetPauseScreen();
        }

        private void SetGameOverScreen()
        {
            Time.timeScale = IsGameOver ? 0 : 1;
            _gameOverText.gameObject.SetActive(IsGameOver);
            _gameOverImage.enabled = IsGameOver;
            _restartButton.gameObject.SetActive(IsGameOver);
            _restartButtonText.gameObject.SetActive(IsGameOver);
            _exitGameButton.gameObject.SetActive(IsGameOver);
            _exitGameText.gameObject.SetActive(IsGameOver);
        }

        private void SetPauseScreen()
        {
            Time.timeScale = IsPaused ? 0 : 1;
            CountdownTimer.isPaused = IsPaused;
            _pauseText.gameObject.SetActive(IsPaused);
            _pauseImage.enabled = IsPaused;
            _pauseRestartButton.gameObject.SetActive(IsPaused);
            _pauseRestartButtonText.gameObject.SetActive(IsPaused);
            _pauseExitGameButton.gameObject.SetActive(IsPaused);
            _pauseExitGameText.gameObject.SetActive(IsPaused);
        }
    }
}