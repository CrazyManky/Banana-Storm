using UnityEngine;

namespace _Project.Screpts.SOConfigs
{
    [CreateAssetMenu(fileName = "PlayerWallet", menuName = "SOConfigs/PlayerWallet")]
    public class PlayerWallet : ScriptableObject
    {
        [SerializeField] private int _playerWallet;

        public int PlayerValue => _playerWallet;
    }
}
