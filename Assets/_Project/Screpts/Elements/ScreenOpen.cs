using DG.Tweening;
using UnityEngine;

namespace _Project.Screpts.Elements
{
    [RequireComponent(typeof(RectTransform))]
    public class ScreenOpen : MonoBehaviour
    {
        [SerializeField] private float _startValue;
        [SerializeField] private float _endValue;
        [SerializeField] private float _duration;

        private RectTransform _rectTransform;

        private void Awake() => _rectTransform = GetComponent<RectTransform>();
        
        public void Open() => _rectTransform.DOAnchorPosY(_endValue, _duration);

        public void Close() => _rectTransform.DOAnchorPosY(_startValue, _duration)
            .OnComplete(() => { Destroy(gameObject); });
    }
}