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
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private PlayerValetView _playerWalletView;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Sprite _defaultBackground;
        [SerializeField] private Sprite _selectedBackground;
        [SerializeField] private RectTransform _instancePoint;
        [SerializeField] private RectTransform _instanceScreenPoint;
        [SerializeField] private GameEntryPoint _entryPoint;
        [SerializeField] private Button _playButton;

        [Header("MenuButtons")] [SerializeField]
        private Image[] _images;

        [Header("Settings")] [SerializeField] private SettingsMenu settingsMenu;
        [SerializeField] private SettingsModel _settingsModel;
        [Header("Lidear")] [SerializeField] private LidearScreen _lidearScreen;

        [Header("ShopScreen")] [SerializeField]
        private ShopScreen _shopScreen;

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
            _serviceLocator.AddService(_audioManager);
            _audioManager.PlayMenu();
        }

        public void MenuOpen()
        {
            _audioManager.PlayMenu();
            gameObject.SetActive(true);
        }


        public void OpenSettingsMenu()
        {
            _audioManager.PlayButtonClick();
            if (_activeScreen != null)
                _activeScreen.Close();
            _backgroundImage.sprite = _defaultBackground;
            DisableAllButtonsView();
            var presenter = new SettingsPresenter(_settingsModel);
            var _viewInstance = Instantiate(settingsMenu, transform);
            _viewInstance.GetComponent<RectTransform>().position = _instancePoint.position;
            _viewInstance.Init(presenter);
            _activeScreen = _viewInstance;
        }

        public void GamePlay()
        {
            _audioManager.PlayGame();
            _audioManager.PlayButtonClick();
            _backgroundImage.sprite = _defaultBackground;
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
            _playButton.gameObject.SetActive(true);
        }

        public void ShowShopActive()
        {
            _audioManager.PlayGame();
            if (_activeShop)
            {
                DisableAllButtonsView();
                _activeScreen.Close();
                _backgroundImage.sprite = _defaultBackground;
                _activeShop = false;
                return;
            }

            if (_activeScreen != null)
                Destroy(_activeScreen.gameObject);
            _backgroundImage.sprite = _selectedBackground;
            DisableAllButtonsView();
            _playButton.gameObject.SetActive(false);
            _images[0].enabled = true;
            _activeShop = true;
            _activeScreen = Instantiate(_shopScreen, _instanceScreenPoint);
            _activeScreen.Init();
        }

        public void ShowRatingActive()
        {
            _audioManager.PlayGame();
            if (_activeLiderBoard)
            {
                DisableAllButtonsView();
                _activeScreen.Close();
                _activeLiderBoard = false;
                return;
            }

            if (_activeScreen != null)
                Destroy(_activeScreen.gameObject);

            _backgroundImage.sprite = _defaultBackground;
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