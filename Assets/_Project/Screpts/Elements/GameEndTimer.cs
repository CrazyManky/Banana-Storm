using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using Services;
using TMPro;
using UnityEngine;

namespace _Project.Screpts.Elements
{
    public class GameEndTimer : MonoBehaviour, IPauseItem
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private float _stepTimer;

        private Coroutine _coroutineTimer;
        private PauseService _pauseService;
        private float _remainingTime;
        private bool _isPaused;

        public event Action OnTimerEnd;

        private void Start()
        {
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
            _pauseService.AddPauseItem(this);
        }

        public void Init()
        {
            _remainingTime = 90f;
            if (_coroutineTimer == null)
                _coroutineTimer = StartCoroutine(TimerRoutine());
        }

        private IEnumerator TimerRoutine()
        {
            var waitForSecondsRealtime = new WaitForSecondsRealtime(_stepTimer);
            while (_remainingTime > 0)
            {
                if (!_isPaused)
                {
                    _remainingTime -= _stepTimer;
                    _remainingTime = Mathf.Max(_remainingTime, 0);
                    UpdateTimerUI();
                }

                yield return waitForSecondsRealtime;
            }

            _remainingTime = 0;
            UpdateTimerUI();
            OnTimerEnd?.Invoke();
        }

        private void UpdateTimerUI()
        {
            int minutes = Mathf.FloorToInt(_remainingTime / 60);
            int seconds = Mathf.FloorToInt(_remainingTime % 60);
            _timerText.text = $"{minutes:D2}:{seconds:D2}"; // Формат 00:00
        }

        private void StartSpawnRoutine()
        {
            if (_coroutineTimer == null)
                _coroutineTimer = StartCoroutine(TimerRoutine());
        }

        private void StopSpawnRoutine()
        {
            if (_coroutineTimer != null)
            {
                StopCoroutine(_coroutineTimer);
                _coroutineTimer = null;
            }
        }

        public void PauseActive()
        {
            _isPaused = true;
            StopSpawnRoutine();
        }

        public void DisablePause()
        {
            _isPaused = false;
            if (gameObject.activeSelf)
                StartSpawnRoutine();
        }

        public void DisableTimer()
        {
            if (_coroutineTimer != null)
            {
                StopCoroutine(TimerRoutine());
                _coroutineTimer = null;
            }
        }
    }
}