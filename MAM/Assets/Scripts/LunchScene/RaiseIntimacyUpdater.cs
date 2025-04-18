using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaiseIntimacyUpdater: MonoBehaviour
{
    [SerializeField] private Image _studentIcon;
    [SerializeField] private TextMeshProUGUI _studentName;
    [SerializeField] private TextMeshProUGUI _intimacyText;

    public Student Student { get; private set; }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    
    public void SetStudent(Student student)
    {
        Student = student;
        _studentIcon.sprite = student.Icon;
        _studentName.text = student.Name;
        SetIntimacy(student.Intimacy);
    }

    public void SetIntimacy(float intimacy)
    {
        _intimacyText.text = intimacy.ToString("f0");
    }
}
