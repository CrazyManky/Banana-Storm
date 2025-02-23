using System;
using _Project.Screpts.SOConfigs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShopItem : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _button;
    [SerializeField] private TextMeshProUGUI _textButton;
    [SerializeField] private Sprite _chaseSprite;
    [SerializeField] private Sprite _noChaseSprite;

    private string _chaset = "choosed";
    private string _noChase = "choose";
    private ShopElement _shopElement;
    private int _itemIndex;
    public event Action<int> OnChaseItem;
    public event Action<int> OnPurchaseItem;

    public void SetData(int itemIndex, ShopElement shopElement)
    {
        _itemIndex = itemIndex;
        _icon.sprite = shopElement.Icon;
        _shopElement = shopElement;
        _text.text = $"{shopElement.Price}";
        if (shopElement.IActive)
        {
            _button.sprite = _noChaseSprite;
            _textButton.text = _noChase;
            if (shopElement.ISelected)
            {
                _textButton.text = _chaset;
                _button.sprite = _chaseSprite;
            }
        }
    }

    public void Purchase()
    {
        if (_shopElement.IActive)
        {
            _textButton.text = _chaset;
            _button.sprite = _chaseSprite;
            OnPurchaseItem?.Invoke(_itemIndex);
            return;
        }

        if (_shopElement.Price <= _playerWallet.PlayerValue && !_shopElement.IActive)
        {
            _playerWallet.RemoveValue(_shopElement.Price);
            _button.sprite = _chaseSprite;
            _textButton.text = _chaset;
            OnPurchaseItem?.Invoke(_itemIndex);
        }
    }
}