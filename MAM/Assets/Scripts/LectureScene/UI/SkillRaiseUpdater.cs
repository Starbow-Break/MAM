using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillRaiseUpdater : MonoBehaviour
{
    [SerializeField] private Image _icon = null;
    [SerializeField] private TextMeshProUGUI _studentName = null;
    [SerializeField] private TextMeshProUGUI _lectureType = null;
    [SerializeField] private TextMeshProUGUI _statLevel = null;

    public void SetInfo(Sprite icon, string studentName, string lectureType, float statLevel)
    {
        _icon.sprite = icon;
        _studentName.text = studentName;
        _lectureType.text = lectureType;
        _statLevel.text = statLevel.ToString();
    }   

    public void SetLevel(float level)
    {
        _statLevel.text = level.ToString();
    }
}
