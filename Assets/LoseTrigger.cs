using System;
using _Project.Screpts.Elements;
using _Project.Screpts.GamePlay.InstancePanel;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Panel panel))
        {
            if (!panel.IDisabled)
                _gameUI.ShowGameOver();
        }
    }
}