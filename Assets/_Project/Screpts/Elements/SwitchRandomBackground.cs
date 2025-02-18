using UnityEngine;
using UnityEngine.UI;

namespace _Project.Screpts
{
    [RequireComponent(typeof(Image))]
    public class SwitchRandomBackground : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _image.sprite = _sprites[Random.Range(0, _sprites.Length)];
        }
    }
}