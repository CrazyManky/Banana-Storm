using _Project.Screpts.ScreenPause;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private PauseScreen _pauseScreen;

    public void Init() => gameObject.SetActive(true);

    public void PauseGame()
    {
        var instanceScreen = Instantiate(_pauseScreen, transform);
        instanceScreen.Init();
    }

    public void Dispose() => gameObject.SetActive(false);
}