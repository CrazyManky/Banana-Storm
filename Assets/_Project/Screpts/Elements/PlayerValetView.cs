using _Project.Screpts.SOConfigs;
using TMPro;
using UnityEngine;

namespace _Project.Screpts.Elements
{
    public class PlayerValetView : MonoBehaviour
    {
        [SerializeField] private PlayerWallet _playerWallet;
        [SerializeField] private TextMeshProUGUI _textValue;

        private void Awake() => _textValue.text = $"{_playerWallet.PlayerValue}";
    }
}