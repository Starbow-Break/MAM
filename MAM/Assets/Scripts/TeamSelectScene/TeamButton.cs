using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamButton : Button
{
    public override void OnSelect(BaseEventData eventData) {  }
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }
}
