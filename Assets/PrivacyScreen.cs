using _Project.Screpts;
using Services;
using UnityEngine;

public class PrivacyScreen : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
    }

    public void Close()
    {
        _audioManager.PlayButtonClick();
        Destroy(gameObject);
    }
}