using _Project.Screpts.Elements;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.LiderBoardScreen;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsData;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsPresent;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsView;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screpts.MenuScreen
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private RectTransform _instancePoint;
        [SerializeField] private RectTransform _instanceScreenPoint;
        [SerializeField] private GameEntryPoint _entryPoint;

        [Header("MenuButtons")] [SerializeField]
        private Image[] _images;

        [Header("Settings")] [SerializeField] private SettingsMenu settingsMenu;
        [SerializeField] private SettingsModel _settingsModel;
        [Header("Lidear")] [SerializeField] private LidearScreen _lidearScreen;

        private View _activeScreen;
        private PauseService _pauseService = new();
        private bool _activeShop = false;
        private bool _activeLiderBoard = false;
        private ServiceLocator _serviceLocator;

        private void Awake() => DisableAllButtonsView();

        private void Start()
        {
            ServiceLocator.Init();
            _serviceLocator = ServiceLocator.Instance;
            _serviceLocator.AddService(_pauseService);
            _serviceLocator.AddService(_entryPoint);
        }

        public void MenuOpen() => gameObject.SetActive(true);


        public void OpenSettingsMenu()
        {
            if (_activeScreen != null)

                _activeScreen.Close();

            DisableAllButtonsView();
            var presenter = new SettingsPresenter(_settingsModel);
            var _viewInstance = Instantiate(settingsMenu, transform);
            _viewInstance.GetComponent<RectTransform>().position = _instancePoint.position;
            _viewInstance.Init(presenter);
            _activeScreen = _viewInstance;
        }

        public void GamePlay()
        {
            _entryPoint.Initialize();
            MenuClose();
        }

        private void DisableAllButtonsView()
        {
            foreach (Image image in _images)
            {
                image.enabled = false;
            }

            _activeShop = false;
            _activeLiderBoard = false;
        }

        public void ShowShopActive()
        {
            if (_activeShop)
                return;
            if (_activeScreen != null)
                Destroy(_activeScreen.gameObject);
            DisableAllButtonsView();
            _images[0].enabled = true;
            _activeShop = true;
        }

        public void ShowRatingActive()
        {
            if (_activeLiderBoard)
                return;

            if (_activeScreen != null)
                Destroy(_activeScreen.gameObject);
            DisableAllButtonsView();
            _activeLiderBoard = true;
            _images[1].enabled = true;
            _activeScreen = Instantiate(_lidearScreen, _instanceScreenPoint);
            _activeScreen.Init();
        }

        public void MenuClose()
        {
            gameObject.SetActive(false);
        }
    }
}