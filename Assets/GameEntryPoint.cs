using System;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine;
using _Project.Screpts.GamePlay.InstancePanel;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private PanelInstance _panelInstance;
    [SerializeField] private GameUI _gameUI;

    private GameFSM _gameFsm;

    private void Start() => Initialize();

    public void Initialize()
    {
        gameObject.SetActive(true);
        _gameFsm = new GameFSM(_panelInstance, _gameUI);
        _gameFsm.EnterState<GamePlayState>();
    }
}