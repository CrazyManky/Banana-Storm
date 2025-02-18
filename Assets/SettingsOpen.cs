using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SettingsOpen : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Rect _defaultPosition;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _defaultPosition = _rectTransform.rect;
    }

    public void Open() => _rectTransform.DOAnchorPosY(0, 1f);

    public void Close() => _rectTransform.DOAnchorPosY(-1899, 1f);
}