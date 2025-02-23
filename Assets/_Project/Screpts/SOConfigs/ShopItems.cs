using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Screpts.SOConfigs
{
    [CreateAssetMenu(fileName = "ShopItems", menuName = "ShopItems")]
    public class ShopItems : ScriptableObject
    {
        [SerializeField] private List<ShopElement> _shopItems;

        public int Count => _shopItems.Count;

        public int SelectedItem { get; private set; }

        public ShopElement GetItem(int index)
        {
            return _shopItems[index];
        }

        public ShopElement GetSelectedItem()
        {
            var itemSelected = _shopItems[SelectedItem];
            if (itemSelected.IActive && itemSelected.ISelected)
            {

                return itemSelected;
            }
            return null;
        }

        private void SelectItem(int index)
        {
            _shopItems[SelectedItem].Deselect();
            SelectedItem = index;
            _shopItems[SelectedItem].Select();
        }

        public void UnlockItem(int index)
        {
            _shopItems[index].Unlock();
            SelectItem(index);
        }
    }


    [Serializable]
    public class ShopElement
    {
        public Sprite Icon;
        public int Price;

        public bool IActive;
        public bool ISelected;

        public void Unlock() => IActive = true;
        public void Select() => ISelected = true;
        public void Deselect() => ISelected = false;
    }
}