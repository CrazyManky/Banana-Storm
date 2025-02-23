using _Project.Screpts.GamePlay.GamePlayFinalStateMashine;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using Services;
using UnityEngine;

namespace _Project.Screpts.ScreenPause
{
    public class PauseScreen : MonoBehaviour
    {
        private PauseService _pauseService;
        private GameEntryPoint _gameEntryPoint;
        private AudioManager _audioManager;

        public void Init()
        {
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
            _gameEntryPoint = ServiceLocator.Instance.GetService<GameEntryPoint>();
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
            _pauseService.PauseExecute();
        }

        public void ContinueGame()
        {
            _audioManager.PlayButtonClick();
            _pauseService.DisablePause();
            Destroy(gameObject);
        }

        public void OpenMenu()
        {
            _audioManager.PlayButtonClick();
            _gameEntryPoint.MenuOpen();
            Destroy(gameObject);
        }

        public void RestartGame()
        {
            _audioManager.PlayButtonClick();
            _gameEntryPoint.GameFSM.EnterState<GamePlayState>();
            _pauseService.DisablePause();
            Destroy(gameObject);
        }
    }
}