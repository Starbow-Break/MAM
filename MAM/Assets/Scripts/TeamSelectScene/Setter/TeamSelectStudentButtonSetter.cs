using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable All
public class TeamSelectStudentButtonSetter : MonoBehaviour
{
    [Header("Updater")]
    [SerializeField] private StudentButtonUpdater _studentButtonUpdater;
    [SerializeField] private StudentInfoUpdater _studentInfoUpdater;

    [Header("Instantiate")]
    [SerializeField] private Transform _parent;
    
    private List<StudentButtonUpdater> _updaters = new List<StudentButtonUpdater>();
    
    private void OnEnable()
    {
        var controller = TeamSelectSceneManager.Controller;
        controller.OnChangeTeam += () => UpdateStudentButtons();
        controller.OnChangeStudent += () => UpdateStudentButtons();
    }

    private void OnDisable()
    {
        var controller = TeamSelectSceneManager.Controller;
        controller.OnChangeTeam -= () => UpdateStudentButtons();
        controller.OnChangeStudent -= () => UpdateStudentButtons();
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
                Debug.Log($"Click Student : {_newUpdater.Student.ID}");
                TeamSelectSceneManager.Controller.SelectStudent(student);
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
        var controller = TeamSelectSceneManager.Controller;
        foreach (StudentButtonUpdater updater in _updaters)
        {
            if (controller.IsRegistered(updater.Student))
            {
                if (controller.IsRegisteredSelectedTeam(updater.Student))
                {
                    updater.SetStatus(StudentButton.EStatus.Selected);
                }
                else {
                    updater.SetStatus(StudentButton.EStatus.Disabled);
                }
            }
            else
            {
                updater.SetStatus(StudentButton.EStatus.Normal);
            }
        }
    }
}
