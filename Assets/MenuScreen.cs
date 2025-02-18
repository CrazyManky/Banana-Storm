using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private SettingsScreen _settingsScreen;
    
    public void OpenSettingsMenu() => _settingsScreen.OpenSettings();
}