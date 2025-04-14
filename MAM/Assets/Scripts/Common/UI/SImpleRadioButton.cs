using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SImpleRadioButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SimpleRadioButtonAnimator _animator;

    public UnityAction ActOnClick { get; set; }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        ActOnClick?.Invoke();
    }

    public void PlaySelectAnimation()
    {
        _animator.PlaySelectAnimation();
    }
    
    public void PlayDeSelectAnimation()
    {
        _animator.PlayNormalAnimation();
    }
}
