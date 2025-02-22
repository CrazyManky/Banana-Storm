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
        [SerializeField] private Panel _panel;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _delayInstance;
        [SerializeField] private PlayerValetView _playerValetView;


        private PullObjects<Panel> _pullObjects;
        private PauseService _pauseService;
        private float _panelSpeed = 3f;
        private float _despawnHeightOffset = 1f;
        private bool _pauseActive = false;
        private Coroutine _coroutine;

        public void Init()
        {
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
            _pauseService.AddPauseItem(this);
            _pullObjects = new(_panel, 10);
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
                var item = _pullObjects.GetItem(_spawnPoints[Random.Range(0, _spawnPoints.Length)]);
                item.SetSpeed(_panelSpeed);
                yield return waitForSecondsRealtime;
                if (_pauseActive)
                {
                    item.Active(false);
                    yield break;
                }
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