using _Project.Screpts.Services;
using _Project.Screpts.SOConfigs;
using UnityEngine;

namespace _Project.Screpts
{
    public class AudioManager : MonoBehaviour, IService
    {
        [SerializeField] private SoundConfigs _soundConfig;
        [SerializeField] private AudioSource _buttonClickListener;
        [SerializeField] private AudioSource _gameSound;
        [SerializeField] private AudioSource _menuMusic;

        private void Awake()
        {
            _soundConfig.Load();
            _gameSound.volume = _soundConfig.VolumeMusic;
            _menuMusic.volume = _soundConfig.VolumeMusic;
            _buttonClickListener.volume = _soundConfig.VolumeSound;
        }

        public void PlayButtonClick()
        {
            _buttonClickListener.Play();
        }

        public void PlayGame()
        {
            _menuMusic.Stop();
            _gameSound.Play();
        }

        public void PlayMenu()
        {
            _gameSound.Stop();
            _menuMusic.Play();
        }

        private void Update()
        {
            _gameSound.volume = _soundConfig.VolumeMusic;
            _menuMusic.volume = _soundConfig.VolumeMusic;
            _buttonClickListener.volume = _soundConfig.VolumeSound;
        }
    }
}