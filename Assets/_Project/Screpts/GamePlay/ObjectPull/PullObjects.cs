using System.Collections.Generic;
using _Project.Screpts.GamePlay.InstancePanel;
using UnityEngine;

namespace _Project.Screpts.GamePlay.ObjectPull
{
    public class PullObjects<T> where T : MonoBehaviour, IPullObject
    {
        private T _item;
        public List<T> ListItems { get; private set; }
        private int _countItems;

        public PullObjects(T item, int count)
        {
            _item = item;
            _countItems = count;
            ListItems = new List<T>();
        }

        public void Initialize()
        {
            for (int i = 0; i <= _countItems; i++)
            {
                var instanceItem = Object.Instantiate(_item);
                instanceItem.Active(false);
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
    }
}