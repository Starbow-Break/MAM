using UnityEngine.UI;
using UnityEngine;

public enum EUnityWindowType
{
    None = 0,
    Console = 1,
    Game = 2,
    Inspector = 3,
    Project = 4,
    Scene = 5
}


[System.Serializable]
public class UnityWindowCue : MonoBehaviour
{
    [SerializeField] private Image _icon = null;
    
    public EUnityWindowType WindowType = EUnityWindowType.None;
    public KeyCode RequiredKey = KeyCode.None;
    public Sprite Icon = null;

    private float _incompleteAlpha = 0.5f;
    
    public void SetCue(EUnityWindowType windowType, Sprite icon, KeyCode requiredKey)
    {
        Icon = icon;
        WindowType = windowType;
        RequiredKey = requiredKey;
        
        _icon.sprite = icon;
        SetComplete();
    }

    public void SetComplete()
    {
        Color color = _icon.color;
        color.a = 1f;
        _icon.color = color;
    }

    public void SetIncomplete()
    {
        Color color = _icon.color;
        color.a = _incompleteAlpha;
        _icon.color = color;    
    }
}
