using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ButtonsOpen : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private RectTransform _rectTransform;

    private void Awake() => _rectTransform = GetComponent<RectTransform>();

    private void Start() => OpenButtonsAnimation();
    
    private void OpenButtonsAnimation()
    {
        foreach (Button button in _buttons)
            button.interactable = false;

        _rectTransform.DOAnchorPosY(0f, 1f).OnComplete(() =>
        {
            foreach (Button button in _buttons)
                button.interactable = true;
        });
    }
}