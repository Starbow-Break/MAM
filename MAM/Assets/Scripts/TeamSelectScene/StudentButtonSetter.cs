using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable All
public class StudentButtonSetter : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private TeamSelectSceneController _controller;

    [Header("Updater")]
    [SerializeField] private StudentButtonUpdater _studentButtonUpdater;
    [SerializeField] private StudentInfoUpdater _studentInfoUpdater;

    [Header("Instantiate")]
    [SerializeField] private Transform _parent;
    
    private List<StudentButtonUpdater> _updaters = new List<StudentButtonUpdater>();

    private void OnEnable()
    {
        _controller.OnChangeTeam += () => UpdateStudentButtons();
        _controller.OnChangeStudent += () => UpdateStudentButtons();
    }

    private void OnDisable()
    {
        _controller.OnChangeTeam -= () => UpdateStudentButtons();
        _controller.OnChangeStudent -= () => UpdateStudentButtons();
    }
    
    public void Initialize(List<Student> students)
    {
        foreach (Student student in students)
        {
            StudentButtonUpdater _newUpdater = Instantiate(_studentButtonUpdater, _parent);
            
            _newUpdater.StudentID = student.ID;
            _newUpdater.SetImage(student.Icon);
            _newUpdater.AddOnClickEventListener(() => 
            {
                Debug.Log($"Click Student : {_newUpdater.StudentID}");
                _controller.SelectStudent(student);
            });
            _newUpdater.AddOnHoverEventListener(() =>
            {
                _studentInfoUpdater.SetActive(true);
                _studentInfoUpdater.SetStudent(_newUpdater.StudentID);
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
            if (_controller.IsRegistered(updater.StudentID))
            {
                if (_controller.IsRegisteredSelectedTeam(updater.StudentID))
                {
                    updater.SetInteractable(true);
                    updater.SetSelected(true);
                }
                else {
                    updater.SetInteractable(false);
                }
            }
            else {
                updater.SetInteractable(true);
                updater.SetSelected(false);
            }
        }
    }
}
