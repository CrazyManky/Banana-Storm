using System.Collections;
using _Project.Screpts.Elements;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.GamePlay.ObjectPull;
using Services;
using UnityEngine;

namespace _Project.Screpts.GamePlay.InstancePanel
{
    public class PanelInstance : MonoBehaviour, IPauseItem
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Panel _purple;
        [SerializeField] private Panel _green;
        [SerializeField] private Panel _blue;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _delayInstance;
        [SerializeField] private PlayerValetView _playerValetView;

        private PullObjects<Panel> _pullObjects;
        private PauseService _pauseService;
        private float _panelSpeed = 3f;
        private float _despawnHeightOffset = 1f;
        private bool _pauseActive = false;
        private Coroutine _coroutine;
        private Transform _lastSpawnPoint;
        private Panel _lastSpawnedPanel; 
        private float _minSpawnDistance = 5.0f; 

        public void Init()
        {
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
            _pauseService.AddPauseItem(this);
            _pullObjects = new(_purple,_green,_blue, 10);
            _pullObjects.Initialize();
            StartSpawnRoutine();
        }

        private void Update()
        {
            float despawnY = -_camera.orthographicSize - _despawnHeightOffset;
            for (int i = 0; i < _pullObjects.ListItems.Count; i++)
            {
                if (_pullObjects.ListItems[i].transform.position.y < despawnY)
                    _pullObjects.RemoveItem(_pullObjects.ListItems[i]);
            }
        }

        private IEnumerator SpawnPanel()
        {
            var waitForSecondsRealtime = new WaitForSecondsRealtime(_despawnHeightOffset);

            while (!_pauseActive)
            {
                if (_lastSpawnedPanel != null && Vector2.Distance(_lastSpawnedPanel.transform.position, transform.position) < _minSpawnDistance)
                {
                    yield return null; 
                    continue;
                }
                
                Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                _lastSpawnedPanel = _pullObjects.GetItem(spawnPoint); 

                if (_pauseActive)
                {
                    _lastSpawnedPanel.Active(false);
                    yield break;
                }

                _lastSpawnedPanel.SetSpeed(_panelSpeed);
                yield return waitForSecondsRealtime;
            }
        }

        private void StartSpawnRoutine()
        {
            if (_coroutine == null)
                _coroutine = StartCoroutine(SpawnPanel());
        }

        private void StopSpawnRoutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        public void PauseActive()
        {
            _pauseActive = true;
            StopSpawnRoutine();
        }

        public void DisablePause()
        {
            _pauseActive = false;
            if (gameObject.activeSelf)
                StartSpawnRoutine();
        }

        public void Dispose()
        {
            StopSpawnRoutine();
            _pullObjects.DisposeObject();
        }
    }
}