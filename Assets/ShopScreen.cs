using System.Collections.Generic;
using _Project.Screpts;
using _Project.Screpts.MenuScreen.SettingsScreen.SettingsPresent;
using _Project.Screpts.SOConfigs;
using Services;
using UnityEngine;

public class ShopScreen : View
{
    [SerializeField] private ShopItems _shopItems;
    [SerializeField] private ShopItem _shopItem;
    [SerializeField] private RectTransform _shopItemContainer;

    private List<ShopItem> _instanceItems = new List<ShopItem>();
    private AudioManager _audioManager;

    public override void Init()
    {
        _audioManager = ServiceLocator.Instance.GetService<AudioManager>();
        _screenOpen.Open();
        for (int i = 0; i < _shopItems.Count; i++)
        {
            var instanceItem = Instantiate(_shopItem, _shopItemContainer);
            instanceItem.SetData(i, _shopItems.GetItem(i));
            _instanceItems.Add(instanceItem);
            instanceItem.OnPurchaseItem += _shopItems.UnlockItem;
            instanceItem.OnPurchaseItem += PurchaseItem;
        }
    }

    public override void Init(SettingsPresenter presenter)
    {
    }

    private void PurchaseItem(int itemIndex)
    {
        _audioManager.PlayButtonClick();
        for (int i = 0; i < _instanceItems.Count; i++)
        {
            if (i == itemIndex)
                continue;
            _instanceItems[i].SetData(i, _shopItems.GetItem(i));
        }
    }

    public override void Close()
    {
        _instanceItems.ForEach((item) => { item.OnPurchaseItem -= _shopItems.UnlockItem; });
        _instanceItems.ForEach((item) => { item.OnPurchaseItem -= PurchaseItem; });
        _screenOpen.Close();
    }
}