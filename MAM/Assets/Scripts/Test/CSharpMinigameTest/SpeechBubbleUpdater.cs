using TMPro;
using UnityEngine;

public class SpeechBubbleUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
