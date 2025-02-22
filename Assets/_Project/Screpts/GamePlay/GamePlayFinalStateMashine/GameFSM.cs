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

        public GameFSM(PanelInstance panelInstance, GameUI _gameUI, PlayerInstance playerInstance)
        {
            _states = new Dictionary<Type, IStateGamePlay>()
            {
                [typeof(GamePlayState)] = new GamePlayState(panelInstance, _gameUI, playerInstance),
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
        private PauseService _pauseService;

        public GamePlayState(PanelInstance panelInstance, GameUI gameUI, PlayerInstance playerInstance)
        {
            _playerInstance = playerInstance;
            _panelInstance = panelInstance;
            _gameUI = gameUI;
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
        }

        public void EnterState()
        {
            _panelInstance.Init();
            _gameUI.Init();
            _playerInstance.Init();
            _pauseService.DisablePause();
        }

        public void ExitState()
        {
            _panelInstance.Dispose();
            _gameUI.Dispose();
            _playerInstance.DisableJumper();
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