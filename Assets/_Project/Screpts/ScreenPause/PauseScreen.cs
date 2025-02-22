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

        public void Init()
        {
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
            _gameEntryPoint = ServiceLocator.Instance.GetService<GameEntryPoint>();
            _pauseService.PauseExecute();
        }

        public void ContinueGame()
        {
            _pauseService.DisablePause();
            Destroy(gameObject);
        }

        public void OpenMenu()
        {
            _gameEntryPoint.MenuOpen();
            Destroy(gameObject);
        }

        public void RestartGame()
        {
            _gameEntryPoint.GameFSM.EnterState<GamePlayState>();
            _pauseService.DisablePause();
            Destroy(gameObject);
        }
    }
}