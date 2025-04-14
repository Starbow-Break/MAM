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
    
    public void Initialize(List<Student> students)
    {
        foreach (Student student in students)
        {
            StudentButtonUpdater _newUpdater = Instantiate(_studentButtonUpdater, _parent);
            _newUpdater.StudentID = student.ID;
            _newUpdater.SetImage(student.Icon);
            
            _newUpdater.AddOnClickEventListener(() =>
            {
                
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
}
