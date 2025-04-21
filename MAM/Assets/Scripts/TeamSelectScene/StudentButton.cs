using System.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StudentButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public enum EButtonStatus
    {
        Disabled,   // 상호작용 비활성화
        Normal,     // 평상시
        Selected    // 선택됨
    }
    
    [SerializeField] private StudentButtonAnimator _animator;
    
    public UnityAction OnClick { get; set; }
    public UnityAction OnHover { get; set; }
    public UnityAction OnUnHover { get; set; }
    
    public EButtonStatus Status { get; private set; } = EButtonStatus.Normal;

    public void SetStatus(EButtonStatus status)
    {
        Status = status;
        switch (status)
        {
            case EButtonStatus.Disabled:
                _animator.PlayDisabledAnimation();
                break;
            case EButtonStatus.Normal:
                _animator.PlayNormalAnimation();
                break;
            case EButtonStatus.Selected:
                _animator.PlaySelectedAnimation();
                break;
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Status != EButtonStatus.Disabled)
        {
            OnClick?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHover?.Invoke();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        OnUnHover?.Invoke();
    }
}
