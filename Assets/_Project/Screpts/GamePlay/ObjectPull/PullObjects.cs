using System.Collections.Generic;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.GamePlay.InstancePanel;
using Services;
using UnityEngine;

namespace _Project.Screpts.GamePlay.ObjectPull
{
    public class PullObjects<T> where T : MonoBehaviour, IPullObject, IPauseItem
    {
        private T[] _itemPrefabs;
        public List<T> ListItems { get; private set; }
        private int _countItems;
        private PauseService _pauseService;

        public PullObjects(T itemOne, T itemTwo, T itemFree, int count)
        {
            _itemPrefabs = new T[] { itemOne, itemTwo, itemFree };
            _countItems = count;
            ListItems = new List<T>();
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
        }

        public void Initialize()
        {
            for (int i = 0; i < _countItems; i++)
            {
                var instanceItem = Object.Instantiate(GetRandomPrefab()); // Создаем случайный объект
                instanceItem.Active(false);
                _pauseService.AddPauseItem(instanceItem);
                ListItems.Add(instanceItem);
            }
        }

        public T GetItem(Transform spawnPoint)
        {
            foreach (var item in ListItems)
            {
                if (!item.IActive)
                {
                    ActivateItem(item, spawnPoint);
                    return item;
                }
            }

            var newItem = Object.Instantiate(GetRandomPrefab());
            ActivateItem(newItem, spawnPoint);
            ListItems.Add(newItem);
            return newItem;
        }

        public void RemoveItem(T item)
        {
            item.Active(false);
        }

        public void DisposeObject()
        {
            foreach (var item in ListItems)
            {
                Object.Destroy(item.gameObject);
            }

            ListItems.Clear();
        }

        private T GetRandomPrefab()
        {
            return _itemPrefabs[Random.Range(0, _itemPrefabs.Length)];
        }

        private void ActivateItem(T item, Transform spawnPoint)
        {
            item.Active(true);
            item.transform.SetParent(spawnPoint);
            item.transform.position = spawnPoint.position;
        }
    }
}