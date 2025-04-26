using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct WindowImageSet
{
    public EUnityWindowType WindowType;
    public Sprite HighlightImage;
}
public class UnityScreenController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _screen = null;
    
    [SerializeField] private List<WindowImageSet> _windowImageSets = new List<WindowImageSet>();
    [SerializeField] private Sprite _idleImage = null;
    
    [SerializeField] private GameObject _correctImage = null;
    [SerializeField] private GameObject _incorrectImage = null;
    
    public void HighLightWindow(EUnityWindowType windowType)
    {
        Sprite sprite = _windowImageSets.Find(x => x.WindowType == windowType).HighlightImage;
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
    }
}
