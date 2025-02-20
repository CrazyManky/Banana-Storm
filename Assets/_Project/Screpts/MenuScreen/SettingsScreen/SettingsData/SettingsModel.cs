using System;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsView;
using _Project.Screpts.SOConfigs;
using UnityEngine;

namespace _Project.Screpts.MenuScreen.SettingsScreen.SettingsData
{
    [Serializable]
    public class SettingsModel
    {
        [SerializeField] private SoundConfigs _soundConfigs;
        public void SetSoundVolume(float soundVolume) => _soundConfigs.SetDataSound(soundVolume);

        public void SetMusicVolume(float musicVolume) => _soundConfigs.SetDataMusic(musicVolume);
    }
}