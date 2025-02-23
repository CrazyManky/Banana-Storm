using _Project.Screpts.Elements;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsPresent;
using _Project.Screpts.SOConfigs;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screpts.MenuScreen.SettingsScreen.SettingsView
{
    [RequireComponent(typeof(ScreenOpen))]
    public class SettingsMenu : View
    {
        [SerializeField] private Slider _sliderMusic;
        [SerializeField] private Slider _sliderSound;
        [SerializeField] private SoundConfigs _soundConfigs;
        [SerializeField] private PrivacyScreen _privacyScreen;

        private SettingsPresenter _presenter;
        private AudioManager _audioManager;

        public void OnDisable()
        {
            _sliderMusic.onValueChanged.RemoveListener(_presenter.SetDataMusic);
            _sliderSound.onValueChanged.RemoveListener(_presenter.SetDataVolume);
        }

        public override void Init()
        {
            _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
            _screenOpen.Open();
        }

        public override void Init(SettingsPresenter presenter)
        {
            _presenter = presenter;
            _screenOpen.Open();
            _sliderSound.value = _soundConfigs.VolumeSound;
            _sliderMusic.value = _soundConfigs.VolumeMusic;
            _sliderMusic.onValueChanged.AddListener(_presenter.SetDataMusic);
            _sliderSound.onValueChanged.AddListener(_presenter.SetDataVolume);
        }

        public void ShowPrivacyScreen()
        {
            _audioManager.PlayButtonClick();
            Instantiate(_privacyScreen, transform);
        }

        public override void Close() => Destroy(gameObject);
    }
}