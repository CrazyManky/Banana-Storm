using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(RectTransform))]
public class ButtonsScaleSize : MonoBehaviour
{
    private Button _button;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.localScale = Vector3.zero;
    }

    private void Start() => AnimationSize();

    private void AnimationSize()
    {
        _button.interactable = false;
        _rectTransform.DOScale(new Vector3(1, 1, 1), 1f).OnComplete(() => _button.interactable = true);
    }
}