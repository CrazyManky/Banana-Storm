using System;
using System.Collections.Generic;
using _Project.Screpts.Elements;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.GamePlay.InstancePanel;
using Services;

namespace _Project.Screpts.GamePlay.GamePlayFinalStateMashine
{
    public class GameFSM
    {
        private Dictionary<Type, IStateGamePlay> _states;

        private IStateGamePlay _activeState;

        public GameFSM(PanelInstance panelInstance, GameUI _gameUI, PlayerInstance playerInstance,GameEndTimer gameEndTimer)
        {
            _states = new Dictionary<Type, IStateGamePlay>()
            {
                [typeof(GamePlayState)] = new GamePlayState(panelInstance, _gameUI, playerInstance,gameEndTimer),
                [typeof(DisableState)] = new DisableState(),
            };
        }

        public void EnterState<T>()
        {
            _activeState?.ExitState();
            _activeState = _states[typeof(T)];
            _activeState.EnterState();
        }
    }

    public class GamePlayState : IStateGamePlay
    {
        private PlayerInstance _playerInstance;
        private PanelInstance _panelInstance;
        private GameUI _gameUI;
        private GameEndTimer _gameEndTimer;
        private PauseService _pauseService;

        public GamePlayState(PanelInstance panelInstance, GameUI gameUI, PlayerInstance playerInstance,
            GameEndTimer gameEndTimer)
        {
            _playerInstance = playerInstance;
            _panelInstance = panelInstance;
            _gameUI = gameUI;
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
            _gameEndTimer = gameEndTimer;
        }

        public void EnterState()
        {
            _panelInstance.Init();
            _gameUI.Init();
            _playerInstance.Init();
            _pauseService.DisablePause();
            _gameEndTimer.Init();
            _gameEndTimer.OnTimerEnd += _gameUI.ShowGameWin;
        }

        public void ExitState()
        {
            _panelInstance.Dispose();
            _gameUI.Dispose();
            _playerInstance.DisableJumper();
            _gameEndTimer.DisableTimer();
            _gameEndTimer.OnTimerEnd -= _gameUI.ShowGameWin;
        }
    }

    public class DisableState : IStateGamePlay
    {
        public void EnterState()
        {
        }

        public void ExitState()
        {
        }
    }
}