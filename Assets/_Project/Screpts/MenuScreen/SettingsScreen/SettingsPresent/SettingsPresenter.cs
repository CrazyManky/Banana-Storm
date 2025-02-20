using _Project.Screpts.MenuScreen.SettingsScreen.SettingsData;

namespace _Project.Screpts.MenuScreen.SettingsScreen.SettingsPresent
{
    public class SettingsPresenter
    {
        private SettingsModel _settingsModel;

        public SettingsPresenter(SettingsModel settingsModel)
        {
            _settingsModel = settingsModel;
        }

        public void SetDataMusic(float value) => _settingsModel.SetMusicVolume(value);
        public void SetDataVolume(float value) => _settingsModel.SetSoundVolume(value);
    }
}