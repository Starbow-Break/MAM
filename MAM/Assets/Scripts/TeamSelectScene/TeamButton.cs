using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamButton : Button
{
    public bool IsSelected { get; private set; } = false;

    public override void OnSelect(BaseEventData eventData) {  }
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }
}
