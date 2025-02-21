using System;
using System.Collections.Generic;
using _Project.Screpts.GamePlay.InstancePanel;

namespace _Project.Screpts.GamePlay.GamePlayFinalStateMashine
{
    public class GameFSM
    {
        private Dictionary<Type, IStateGamePlay> _states;

        private IStateGamePlay _activeState;

        public GameFSM(PanelInstance panelInstance, GameUI _gameUI)
        {
            _states = new Dictionary<Type, IStateGamePlay>()
            {
                [typeof(GamePlayState)] = new GamePlayState(panelInstance, _gameUI),
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
        private PanelInstance _panelInstance;
        private GameUI _gameUI;

        public GamePlayState(PanelInstance panelInstance, GameUI gameUI)
        {
            _panelInstance = panelInstance;
            _gameUI = gameUI;
        }

        public void EnterState()
        {
            _panelInstance.Init();
            _gameUI.Init();
        }

        public void ExitState()
        {
        }
    }
}