using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StudentButton : Button
{
    public UnityAction OnHover { get; set; }
    public UnityAction OnUnHover { get; set; }

    public override void OnSelect(BaseEventData eventData) {  }
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (interactable)
        {
            onClick?.Invoke();
        }
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        OnHover?.Invoke();
    }
    
    public override void OnPointerExit(PointerEventData eventData)
    {
        OnUnHover?.Invoke();
    }
}
