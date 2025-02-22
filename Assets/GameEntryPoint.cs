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

    public GameFSM GameFSM;

    public void Initialize()
    {
        ServiceLocator.Instance.AddService(_playerValetView);
        gameObject.SetActive(true);
        GameFSM = new GameFSM(_panelInstance, _gameUI, _playerInstance);
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