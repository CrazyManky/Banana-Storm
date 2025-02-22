using System;
using _Project.Screpts.Elements;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.GamePlay.InstancePanel;
using Services;
using UnityEngine;
using UnityEngine.Serialization;

public class ClickHandler : MonoBehaviour, IPauseItem
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private PlayerInstance _playerInstance;

    private bool _isPaused;
    private PauseService _pauseService;

    private void Start()
    {
        _pauseService = ServiceLocator.Instance.GetService<PauseService>();
        _pauseService.AddPauseItem(this);
    }

    public void Update() => HandleClick();

    private void HandleClick()
    {
        if (_playerInstance.JumperInstance == null || _isPaused)
            return;

        Vector2 inputPosition;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                inputPosition = touch.position;
            }
            else return;
        }
        else return;

        if (inputPosition.y < Screen.height / 1.5f)
        {
            Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(inputPosition);
            TryJumpToPanel(worldPosition);
        }
    }

    private void TryJumpToPanel(Vector2 inputPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(inputPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.TryGetComponent(out Panel panel))
            _playerInstance.JumperInstance.Jump(panel.transform);
    }

    public void PauseActive()
    {
        _isPaused = true;
    }

    public void DisablePause()
    {
        _isPaused = false;
    }
}