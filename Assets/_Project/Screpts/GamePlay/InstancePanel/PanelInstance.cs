using System.Collections;
using System.Collections.Generic;
using _Project.Screpts.GamePlay.ObjectPull;
using UnityEngine;

namespace _Project.Screpts.GamePlay.InstancePanel
{
    public class PanelInstance : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Panel _panel;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _delayInstance;

        private PullObjects<Panel> _pullObjects;
        private float _maxPanelSpeed = 5f;
        private float _panelSpeed = 3f;
        private float _despawnHeightOffset = 1f;

        public void Init()
        {
            _pullObjects = new(_panel, 10);
            _pullObjects.Initialize();
            StartCoroutine(SpawnPanel());
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
            while (true)
            {
                yield return waitForSecondsRealtime;
                var item = _pullObjects.GetItem(_spawnPoints[Random.Range(0, _spawnPoints.Length)]);
                item.SetSpeed(_panelSpeed);
            }
        }
    }
}