using _Project.Screpts.Elements;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsPresent;
using _Project.Screpts.SOConfigs;
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

        private SettingsPresenter _presenter;

        public void OnDisable()
        {
            _sliderMusic.onValueChanged.RemoveListener(_presenter.SetDataMusic);
            _sliderSound.onValueChanged.RemoveListener(_presenter.SetDataVolume);
        }

        public override void Init() => _screenOpen.Open();
        
        public override void Init(SettingsPresenter presenter)
        {
            _presenter = presenter;
            _screenOpen.Open();
            _sliderSound.value = _soundConfigs.VolumeSound;
            _sliderMusic.value = _soundConfigs.VolumeMusic;
            _sliderMusic.onValueChanged.AddListener(_presenter.SetDataMusic);
            _sliderSound.onValueChanged.AddListener(_presenter.SetDataVolume);
        }

        public override void Close() => Destroy(gameObject);
    }
}