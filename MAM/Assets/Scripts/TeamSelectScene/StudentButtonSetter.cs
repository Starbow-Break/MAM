using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
public class StudentButtonSetter : MonoBehaviour
{
    [SerializeField] private StudentButtonUpdater _studentButtonUpdater;
    [SerializeField] private Transform _parent;
    [SerializeField] private StudentInfoUpdater _studentInfoUpdater;
    private List<StudentButtonUpdater> _updaters = new List<StudentButtonUpdater>();
    
    public void Initialize(List<Student> students)
    {
        foreach (Student student in students)
        {
            StudentButtonUpdater _newUpdater = Instantiate(_studentButtonUpdater, _parent);
            _newUpdater.SetImage(student.Icon);
            _newUpdater.AddOnHoverEventListener(() =>
            {
                _studentInfoUpdater.SetActive(true);
                _studentInfoUpdater.SetStudent(student);
            });
            _newUpdater.AddOnUnHoverEventListener(() =>
            {
                _studentInfoUpdater.SetActive(false);
            });
            _updaters.Add(_newUpdater);
        }
    }
}
