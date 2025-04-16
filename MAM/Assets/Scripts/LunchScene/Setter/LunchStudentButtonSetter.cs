using System.Collections.Generic;
using UnityEngine;

public class LunchStudentButtonSetter : MonoBehaviour
{
    [Header("Updater")]
    [SerializeField] private StudentButtonUpdater _studentButtonUpdater;
    [SerializeField] private StudentInfoUpdater _studentInfoUpdater;
    
    [Header("Instantiate")]
    [SerializeField] private Transform _parent;

    private List<StudentButtonUpdater> _updaters = new();
    
    private void OnEnable()
    {
        var controller = LunchSceneManager.Controller;
        controller.OnChangeStudent += () => UpdateStudentButtons();
    }

    private void OnDisable()
    {
        var controller = LunchSceneManager.Controller;
        controller.OnChangeStudent -= () => UpdateStudentButtons();
    }
    
    public void Initialize(List<Student> students)
    {
        foreach (Student student in students)
        {
            StudentButtonUpdater newUpdater = Instantiate(_studentButtonUpdater, _parent);
            newUpdater.SetStudent(student);
            newUpdater.AddOnClickEventListener(() =>
            {
                var controller = LunchSceneManager.Controller;
                controller.SelectStudent(newUpdater.Student);
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
            if (LunchSceneManager.Controller.IsSelected(updater.Student))
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
