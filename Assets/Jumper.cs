using DG.Tweening;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private Transform _currentTarget;

    public void Jump(Transform target)
    {
        Vector3 targetPosition = target.position;
        _currentTarget = target;
        transform.DOJump(targetPosition, 1f, 1, 0.2f)
            .OnComplete(() =>
            {
                AttachToTarget(_currentTarget);
                transform.DOMoveY(_currentTarget.position.y, 0.1f);
            });
    }

    private void AttachToTarget(Transform target)
    {
        transform.SetParent(target); // Делаем объект дочерним для панели
        transform.localPosition = Vector3.zero; // Выравниваем позицию
    }
}