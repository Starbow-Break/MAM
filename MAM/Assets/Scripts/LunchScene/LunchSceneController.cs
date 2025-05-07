using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LunchSceneController : MonoBehaviour
{
    private List<Student> _selectedStudents = new();
    public List<Student> SelectedStudents => _selectedStudents;
    
    private Restaurant _selectedRestaurant = null;
    public Restaurant SelectedRestaurant => _selectedRestaurant;

    public event Action OnChangeRestaurant;
    public event Action OnChangeStudent;

    public int MaxSelectedStudent => _maxSelectedStudent;
    public int SelectedStudentCount => _selectedStudents.Count;

    [SerializeField, Min(1)] private int _maxSelectedStudent = 6;   // 최대로 선택 가능한 학생 수

    #region Query

    public bool IsSelected(Student student)
    {
        return _selectedStudents.Contains(student);
    }
    #endregion
    
    // 학생 선택
    public void SelectStudent(Student student)
    {
        if (IsSelected(student))
        {
            _selectedStudents.Remove(student);
        }
        else
        {
            if (_selectedStudents.Count < _maxSelectedStudent)
            {
                _selectedStudents.Add(student);
            }
        }
        
        OnChangeStudent?.Invoke();
    }
    
    // 학생 선택
    public void SelectRestaurant(Restaurant restaurant)
    {
        _selectedRestaurant = restaurant;
        OnChangeRestaurant?.Invoke();
    }
    
    public void ApplyLunch()
    {
        var raiseIntimacySetter = LunchSceneManager.RaiseIntimacySetter;
        raiseIntimacySetter.ApplyLunch(_selectedStudents, _selectedRestaurant);
    }
}
