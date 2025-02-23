using _Project.Screpts.GamePlay.GamePlayFinalStateMashine;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.SOConfigs;
using Services;
using UnityEngine;

namespace _Project.Screpts.Elements
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private int _rewardValue;
        [SerializeField] private PlayerWallet _playerValet;

        private PauseService _pauseService;
        private GameEntryPoint _gameEntryPoint;
        private AudioManager _audioManager;

        public void Init()
        {
            _playerValet.AddValue(_rewardValue);
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
            _gameEntryPoint = ServiceLocator.Instance.GetService<GameEntryPoint>();
            _audioManager = ServiceLocator.Instance.GetService< AudioManager>();
            _pauseService.PauseExecute();
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