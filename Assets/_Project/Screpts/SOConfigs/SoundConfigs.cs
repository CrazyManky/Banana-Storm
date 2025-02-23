using UnityEngine;

namespace _Project.Screpts.SOConfigs
{
    [CreateAssetMenu(fileName = "SoundConfigs", menuName = "SOConfigs/SoundConfigs")]
    public class SoundConfigs : ScriptableObject
    {
        [SerializeField] private float _volumeSound;
        [SerializeField] private float _volumeMusic;

        public float VolumeSound => _volumeSound;
        public float VolumeMusic => _volumeMusic;

        public void Load()
        {
            _volumeSound = PlayerPrefs.GetFloat("SoundVolume", 1f);
            _volumeMusic = PlayerPrefs.GetFloat("SoundVolume", 1f);
        }

        public void SetDataMusic(float musicVolume)
        {
            _volumeMusic = Mathf.Max(0f, musicVolume);
            PlayerPrefs.SetFloat("VolumeMusic", _volumeMusic);
        }

        public void SetDataSound(float soundVolume)
        {
            _volumeSound = Mathf.Max(0f, soundVolume);
            PlayerPrefs.SetFloat("VolumeSound", _volumeSound);
        }
    }
}