using System.Collections.Generic;
using _Project.Screpts.GamePlay.GamePlayFinalStateMashine.Services;
using _Project.Screpts.GamePlay.InstancePanel;
using Services;
using UnityEngine;

namespace _Project.Screpts.GamePlay.ObjectPull
{
    public class PullObjects<T> where T : MonoBehaviour, IPullObject, IPauseItem
    {
        private T _item;
        public List<T> ListItems { get; private set; }
        private int _countItems;
        private PauseService _pauseService;

        public PullObjects(T item, int count)
        {
            _item = item;
            _countItems = count;
            ListItems = new List<T>();
            _pauseService = ServiceLocator.Instance.GetService<PauseService>();
        }

        public void Initialize()
        {
            for (int i = 0; i <= _countItems; i++)
            {
                var instanceItem = Object.Instantiate(_item);
                instanceItem.Active(false);
                _pauseService.AddPauseItem(instanceItem);
                ListItems.Add(instanceItem);
            }
        }

        public T GetItem(Transform transform)
        {
            for (int i = 0; i <= ListItems.Count; i++)
            {
                if (!ListItems[i].IActive)
                {
                    ListItems[i].Active(true);
                    ListItems[i].transform.SetParent(transform);
                    ListItems[i].transform.position = transform.position;
                    return ListItems[i];
                }
            }

            var instanceItem = Object.Instantiate(_item);
            instanceItem.Active(false);
            ListItems.Add(instanceItem);
            return instanceItem;
        }

        public void RemoveItem(T item)
        {
            item.Active(false);
        }

        public void DisposeObject()
        {
            ListItems.ForEach((item) => { Object.Destroy(item.gameObject); });
            ListItems.Clear();
            ListItems = null;
        }
    }
}