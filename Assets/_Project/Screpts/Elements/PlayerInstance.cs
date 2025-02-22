using UnityEngine;

namespace _Project.Screpts.Elements
{
    public class PlayerInstance : MonoBehaviour
    {
        [SerializeField] private Transform _playerInstancePoint;
        [SerializeField] private Jumper _jumperPrefab;

        public Jumper JumperInstance { get; private set; }

        public void Init()
        {
            JumperInstance = Instantiate(_jumperPrefab, _playerInstancePoint);
            JumperInstance.transform.position = _playerInstancePoint.position;
        }
    
        public void DisableJumper() => Destroy(JumperInstance.gameObject);
    }
}