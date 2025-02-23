using System;
using _Project.Screpts.Elements;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using DG.Tweening;
using Services;
using UnityEngine;

namespace _Project.Screpts.GamePlay.InstancePanel
{
    public class Panel : MonoBehaviour, IPullObject, IPauseItem
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private int _value = 15;

        private PlayerValetView _playerValetView;

        private float _speed;
        private float _fadeStep = 5f;
        private float _animationStep = 0.01f;
        public bool IActive { get; private set; }
        public bool IDisabled { get; private set; }

        private bool _pauseActive = false;
        public event Action<int> OnDisabled;

        private void OnEnable()
        {
            if (_playerValetView != null)
                OnDisabled += _playerValetView.SetValue;
        }

        private void Awake() => _playerValetView = ServiceLocator.Instance.GetService<PlayerValetView>();

        public void Active(bool active)
        {
            if (active)
            {
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g,
                    _spriteRenderer.color.b, 255f);
                IDisabled = false;
            }

            IActive = active;
            gameObject.SetActive(IActive);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Jumper>(out var jumper))
            {
                IDisabled = true;
                _spriteRenderer.DOKill();
                _spriteRenderer.DOFade(0f, 2f)
                    .SetUpdate(true)
                    .OnComplete(() => { OnDisabled?.Invoke(_value); });
            }
        }

        public void SetSpeed(float speed)
        {
            if (speed == 0)
                return;
            _speed = speed;
        }

        public void Update()
        {
            if (_pauseActive)
                return;
            transform.Translate(Vector3.down * (_speed * Time.deltaTime));
        }

        private void OnDisable()
        {
            if (_playerValetView != null)
                OnDisabled -= _playerValetView.SetValue;
        }

        public void PauseActive() => _pauseActive = true;

        public void DisablePause() => _pauseActive = false;
    }

    public interface IPullObject
    {
        public bool IActive { get; }
        public void Active(bool active);
    }
}