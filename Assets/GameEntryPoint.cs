using _Project.Screpts.Elements;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.GamePlay.InstancePanel;
using _Project.Screpts.MenuScreen;
using _Project.Screpts.Services;
using Services;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour, IService
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private PanelInstance _panelInstance;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private PlayerInstance _playerInstance;
    [SerializeField] private PlayerValetView _playerValetView;
    [SerializeField] private GameEndTimer _gameEndTimer;

    public GameFSM GameFSM;

    public void Initialize()
    {
        gameObject.SetActive(true);
        ServiceLocator.Instance.AddService(_playerValetView);
        GameFSM = new GameFSM(_panelInstance, _gameUI, _playerInstance,_gameEndTimer);
        GameFSM.EnterState<GamePlayState>();
    }

    public void MenuOpen()
    {
        _menuScreen.MenuOpen();
        ServiceLocator.Instance.RemoveService(_playerValetView);
        GameFSM.EnterState<DisableState>();
        gameObject.SetActive(false);
    }
}