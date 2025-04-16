using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudentButtonUpdater : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Button _button;
    
    public Student Student;    // Updater가 관여하는 버튼에 대응되는 학생의 ID

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetInteractable(bool interactable)
    {
        _button.interactable = interactable;
        // Todo : 임시
        _image.color = interactable ? Color.white * 1f : Color.white * 0f;
    }

    public void SetSelected(bool selected)
    {
        // Todo : 임시
        _image.color = selected ? Color.white * 0.5f : Color.white * 1f;
    }

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void AddOnClickEventListener(UnityAction action)
    {
        GetComponent<StudentButton>().onClick.AddListener(action);
    }

    public void AddOnHoverEventListener(UnityAction action)
    {
        GetComponent<StudentButton>().OnHover += action;
    }
    
    public void AddOnUnHoverEventListener(UnityAction action)
    {
        GetComponent<StudentButton>().OnUnHover += action;
    }
}
