using System;
using _Project.Screpts.GamePlay.InstancePanel;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Jumper _jumper;

    public void Update() => HandleClick();
    
    private void HandleClick()
    {
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
        {
            Debug.Log("Panel found");
            _jumper.Jump(panel.transform);
        }
    }
}