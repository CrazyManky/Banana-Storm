using _Project.Screpts.Services;
using _Project.Screpts.SOConfigs;
using TMPro;
using UnityEngine;

namespace _Project.Screpts.Elements
{
    public class PlayerValetView : MonoBehaviour, IService
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private TextMeshProUGUI _textValue;

        private void OnEnable() => _playerWallet.OnChange += Refresh;

        private void Awake()
        {
            _playerWallet.Load();
            _textValue.text = $"{_playerWallet.PlayerValue}";
        }

        public void SetValue(int value)
        {
            _playerWallet.AddValue(value);
            _textValue.text = $"{_playerWallet.PlayerValue}";
        }

        public void Refresh()
        {
            _textValue.text = $"{_playerWallet.PlayerValue}";
        }

        private void OnDisable() => _playerWallet.OnChange -= Refresh;
    }
}