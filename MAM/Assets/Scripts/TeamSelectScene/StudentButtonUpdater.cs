using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudentButtonUpdater : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _nameText;

    private StudentButton _studentButton;

    public Student Student { get; private set; } // Updater가 관여하는 버튼에 대응되는 학생

    private void Awake()
    {
        _studentButton = GetComponent<StudentButton>();
    }

    public void SetButtonStatus(StudentButton.EButtonStatus status)
    {
        _studentButton.SetStatus(status);
    }

    public void SetStudent(Student student)
    {
        Student = student;
        SetImage(student.Icon);
        SetNameText(student.Name);
    }

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetNameText(string name)
    {
        _nameText.text = name;
    }

    public void AddOnClickEventListener(UnityAction action)
    {
        _studentButton.OnClick += action;
    }

    public void AddOnHoverEventListener(UnityAction action)
    {
        _studentButton.OnHover += action;
    }
    
    public void AddOnUnHoverEventListener(UnityAction action)
    {
        _studentButton.OnUnHover += action;
    }
}
