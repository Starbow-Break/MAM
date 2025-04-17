using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillRaiseUpdater : MonoBehaviour
{
    [SerializeField] private Image _icon = null;
    [SerializeField] private TextMeshProUGUI _studentName = null;
    [SerializeField] private TextMeshProUGUI _skillType = null;
    [SerializeField] private TextMeshProUGUI _statLevel = null;

    public void SetInfo(Sprite icon, string studentName)
    {
        _icon.sprite = icon;
        _studentName.text = studentName;
    }

    public void SetSkillType(ESkillType skillType)
    {
        _skillType.text = skillType.ToString();
    }
    
    public void SetLevel(float level)
    {
        _statLevel.text = level.ToString("F2");
    }
}
