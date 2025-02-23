using _Project.Screpts.SOConfigs;
using UnityEngine;

namespace _Project.Screpts.Elements
{
    public class PlayerInstance : MonoBehaviour
    {
        [SerializeField] private ShopItems shopItems;
        [SerializeField] private Transform _playerInstancePoint;
        [SerializeField] private Jumper _jumperPrefab;

        public Jumper JumperInstance { get; private set; }

        public void Init()
        {
            JumperInstance = Instantiate(_jumperPrefab, _playerInstancePoint);
            JumperInstance.transform.position = _playerInstancePoint.position;
            var seletdetItem = shopItems.GetSelectedItem();
            if (seletdetItem != null)
                JumperInstance.SetSprite(seletdetItem.Icon);
        }

        public void DisableJumper() => Destroy(JumperInstance.gameObject);
    }
}