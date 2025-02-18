using UnityEngine;

[RequireComponent(typeof(SettingsOpen))]
public class SettingsScreen : MonoBehaviour
{
    private SettingsOpen _settingsOpen;

    private void Awake() => _settingsOpen = GetComponent<SettingsOpen>();
    
    public void OpenSettings() => _settingsOpen.Open();
    
}