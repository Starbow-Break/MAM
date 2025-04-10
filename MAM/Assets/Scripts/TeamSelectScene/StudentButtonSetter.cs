using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
public class StudentButtonSetter : MonoBehaviour
{
    [SerializeField] private StudentButtonUpdater _studentButtonUpdater;
    [SerializeField] private Transform _parent;

    private List<StudentButtonUpdater> _updaters = new List<StudentButtonUpdater>();
    
    public void Initialize(List<Student> students)
    {
        foreach (Student student in students)
        {
            StudentButtonUpdater _newUpdater = Instantiate(_studentButtonUpdater, _parent);
            _newUpdater.SetImage(student.Icon);
            _updaters.Add(_newUpdater);
        }
    }
}
