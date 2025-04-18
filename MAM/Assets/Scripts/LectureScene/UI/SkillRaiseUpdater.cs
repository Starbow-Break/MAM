using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillRaiseUpdater : MonoBehaviour
{
    [SerializeField] private Image _icon = null;
    [SerializeField] private TextMeshProUGUI _studentName = null;
    [SerializeField] private Image[] _fillImages = null;
    [SerializeField] private Image[] _slotImages = null;

    [SerializeField] private Sprite _unityIcon = null;
    [SerializeField] private Sprite _cSharpIcon = null;

    public void SetInfo(Sprite icon, string studentName)
    {
        _icon.sprite = icon;
        _studentName.text = studentName;
    }

    public void SetSkillType(ESkillType skillType)
    {
        Sprite icon;
        
        switch (skillType)
        {
            case ESkillType.Unity:
                icon = _unityIcon;
                break;
            case ESkillType.CSharp:
                icon = _cSharpIcon;
                break;
            default:
                icon = _unityIcon;
                break;
        }

        foreach (Image image in _slotImages)
        {
            image.sprite = icon;
        }

        foreach (var image in _fillImages)
        {
            image.sprite = icon;
        }
    }
    
    public void SetLevel(float level)
    {
        for (int i = 0; i < _fillImages.Length; i++)
        {
            float iconFill = Mathf.Clamp01(level - i);
            _fillImages[i].fillAmount = iconFill;
        }
    }
}
