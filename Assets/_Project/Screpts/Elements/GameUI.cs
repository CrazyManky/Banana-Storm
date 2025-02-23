using _Project.Screpts.ScreenPause;
using Services;
using UnityEngine;

namespace _Project.Screpts.Elements
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private PauseScreen _pauseScreen;
        [SerializeField] private WinScreen _winScreen;
        [SerializeField] private GameOverScreen _gameOverScreen;

        private AudioManager _audioManager;

        public void Init()
        {
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
            gameObject.SetActive(true);
        }

        public void PauseGame()
        {
            _audioManager.PlayButtonClick();
            var instanceScreen = Instantiate(_pauseScreen, transform);
            instanceScreen.Init();
        }

        public void ShowGameWin()
        {
            var instanceScreen = Instantiate(_winScreen, transform);
            instanceScreen.Init();
        }

        public void ShowGameOver()
        {
            var instanceScreen = Instantiate(_gameOverScreen, transform);
            instanceScreen.Init();
        }

        public void Dispose() => gameObject.SetActive(false);
    }
}