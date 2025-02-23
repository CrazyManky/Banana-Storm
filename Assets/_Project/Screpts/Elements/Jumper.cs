using System;
using _Project.Screpts;
using DG.Tweening;
using Services;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _jumpForce;
    private Transform _currentTarget;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }

    public void Jump(Transform target)
    {
        _audioManager.PlayButtonClick();
        Vector3 targetPosition = target.position;
        _currentTarget = target;
        transform.DOJump(targetPosition, 1f, 1, 0.2f)
            .OnComplete(() =>
            {
                AttachToTarget(_currentTarget);
                transform.DOMoveY(_currentTarget.position.y, 0.1f);
            });
    }

    private void AttachToTarget(Transform target)
    {
        transform.SetParent(target); // Делаем объект дочерним для панели
        transform.localPosition = Vector3.zero; // Выравниваем позицию
    }
}