using UnityEngine;

namespace _Project.Screpts.SOConfigs
{
    [CreateAssetMenu(fileName = "PlayerWallet", menuName = "SOConfigs/PlayerWallet")]
    public class PlayerWallet : ScriptableObject
    {
        [SerializeField] private int _playerWallet;

        public int PlayerValue => _playerWallet;
        
        public void Load() => _playerWallet = PlayerPrefs.GetInt("PlayerWallet");
        
        public void AddValue(int value)
        {
            var valueResult = _playerWallet + value;
            PlayerPrefs.SetInt("PlayerWallet", valueResult);
            _playerWallet = valueResult;
        }
    }
}