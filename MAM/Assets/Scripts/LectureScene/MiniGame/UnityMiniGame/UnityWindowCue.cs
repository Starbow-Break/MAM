using System;
using UnityEngine;
using UnityEngine.UI;

public enum EUnityWindowType
{
    None = 0,
    Console = 1,
    Game = 2,
    Inspector = 3,
    Project = 4,
    Scene = 5
}


[Serializable]
public class UnityWindowCue : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public EUnityWindowType WindowType = EUnityWindowType.None;
    public KeyCode RequiredKey = KeyCode.None;
    public Sprite Icon;

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
        var color = _icon.color;
        color.a = 1f;
        _icon.color = color;
    }

    public void SetIncomplete()
    {
        var color = _icon.color;
        color.a = _incompleteAlpha;
        _icon.color = color;
    }
}