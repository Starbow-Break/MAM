using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TeamButton : Button
{
    private static int nextId = 1;
    
    public int TeamId { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        TeamId = nextId++;
    }

    public override void OnSelect(BaseEventData eventData) {  }
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }
}
