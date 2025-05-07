using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct WindowImageSet
{
    public EUnityWindowType WindowType;
    public Sprite HighlightImage;
}

public class UnityScreenController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _screen;

    [SerializeField] private List<WindowImageSet> _windowImageSets = new();
    [SerializeField] private Sprite _idleImage;

    [SerializeField] private GameObject _correctImage;
    [SerializeField] private GameObject _incorrectImage;

    public void HighLightWindow(EUnityWindowType windowType)
    {
        var sprite = _windowImageSets.Find(x => x.WindowType == windowType).HighlightImage;
        _screen.sprite = sprite;
    }

    public void ShowCorrectImage()
    {
        _correctImage.SetActive(true);
    }

    public void ShowIncorrectImage()
    {
        _incorrectImage.SetActive(true);
    }

    public void ShowIdleImage()
    {
        _screen.sprite = _idleImage;
        _correctImage.SetActive(false);
        _incorrectImage.SetActive(false);
    }
}