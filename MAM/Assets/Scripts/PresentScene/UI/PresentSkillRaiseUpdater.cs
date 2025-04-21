using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PresentSkillRaiseUpdater : MonoBehaviour
{
    [SerializeField] private Image _icon = null;
    [SerializeField] private TextMeshProUGUI _studentName = null;
    [SerializeField] private Image[] _unityFillImages = null;
    [SerializeField] private Image[] _CSharpFillImages = null;

    public void SetInfo(Sprite icon, string studentName)
    {
        _icon.sprite = icon;
        _studentName.text = studentName;
    }
    
    public void SetUnityLevel(float level)
    {
        for (int i = 0; i < _unityFillImages.Length; i++)
        {
            float iconFill = Mathf.Clamp01(level - i);
            _unityFillImages[i].fillAmount = iconFill;
        }
    }
    
    public void SetCSharpLevel(float level)
    {
        for (int i = 0; i < _CSharpFillImages.Length; i++)
        {
            float iconFill = Mathf.Clamp01(level - i);
            _CSharpFillImages[i].fillAmount = iconFill;
        }
    }
}
