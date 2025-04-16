using System.Collections.Generic;
using UnityEngine;

public class LunchStudentButtonSetter : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private LunchSceneController _controller;
    
    [Header("Updater")]
    [SerializeField] private StudentButtonUpdater _studentButtonUpdater;
    [SerializeField] private StudentInfoUpdater _studentInfoUpdater;
    
    [Header("Instantiate")]
    [SerializeField] private Transform _parent;

    private List<StudentButtonUpdater> _updaters = new();
    
    private void OnEnable()
    {
        _controller.OnChangeStudent += () => UpdateStudentButtons();
    }

    private void OnDisable()
    {
        _controller.OnChangeStudent += () => UpdateStudentButtons();
    }
    
    public void Initialize(List<Student> students)
    {
        foreach (Student student in students)
        {
            StudentButtonUpdater newUpdater = Instantiate(_studentButtonUpdater, _parent);
            newUpdater.Student = student;
            newUpdater.SetImage(student.Icon);
            
            newUpdater.AddOnClickEventListener(() =>
            {
                _controller.SelectStudent(newUpdater.Student);
            });
            newUpdater.AddOnHoverEventListener(() =>
            {
                _studentInfoUpdater.SetActive(true);
                _studentInfoUpdater.SetStudent(newUpdater.Student);
            });
            newUpdater.AddOnUnHoverEventListener(() =>
            {
                _studentInfoUpdater.SetActive(false);
            });
            
            _updaters.Add(newUpdater);
        }
    }
    
    public void UpdateStudentButtons()
    {
        foreach (StudentButtonUpdater updater in _updaters)
        {
            if (_controller.IsSelected(updater.Student))
            {
                updater.SetStatus(StudentButton.EStatus.Selected);
            }
            else
            {
                updater.SetStatus(StudentButton.EStatus.Normal);
            }
        }
    }
}
