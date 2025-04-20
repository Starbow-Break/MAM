using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudentButtonUpdater : MonoBehaviour
{
    [SerializeField] private Image _image;

    private StudentButton _studentButton;

    public Student Student { get; private set; } // Updater가 관여하는 버튼에 대응되는 학생

    private void Awake()
    {
        _studentButton = GetComponent<StudentButton>();
    }

    public void SetStudent(Student student)
    {
        Student = student;
        SetImage(student.Icon);
    }

    public void SetStatus(StudentButton.EStatus status)
    {
        _studentButton.SetStatus(status);
    }

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
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
