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
            StudentButtonUpdater _newUpdater = Instantiate(_studentButtonUpdater, _parent);
            _newUpdater.Student = student;
            _newUpdater.SetImage(student.Icon);
            
            _newUpdater.AddOnClickEventListener(() =>
            {
                _controller.SelectStudent(_newUpdater.Student);
            });
            _newUpdater.AddOnHoverEventListener(() =>
            {
                _studentInfoUpdater.SetActive(true);
                _studentInfoUpdater.SetStudent(_newUpdater.Student);
            });
            _newUpdater.AddOnUnHoverEventListener(() =>
            {
                _studentInfoUpdater.SetActive(false);
            });
            
            _updaters.Add(_newUpdater);
        }
    }
    
    public void UpdateStudentButtons()
    {
        foreach (StudentButtonUpdater updater in _updaters)
        {
            if (_controller.IsSelected(updater.Student))
            {
                updater.SetSelected(true);
            }
            else
            {
                updater.SetSelected(false);
            }
        }
    }
}
