using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LunchSceneController : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxSelectedStudent = 6;   // 최대로 선택 가능한 학생 수

    private Restaurant _selectedRestaurant = null;
    private List<Student> _selectedStudents = new();
    
    public UnityAction OnChangeRestaurant { get; set; }
    public UnityAction OnChangeStudent { get; set; }

    public List<Student> SelectedStudents => _selectedStudents;
    public Restaurant SelectedRestaurant => _selectedRestaurant;
    public int MaxSelectedStudent => _maxSelectedStudent;
    public int SelectedStudentCount => _selectedStudents.Count;

    #region Query

    public bool IsSelected(Student student)
    {
        return _selectedStudents.Contains(student);
    }
    #endregion
    
    // 학생 선택
    public void SelectStudent(Student student)
    {
        if (_maxSelectedStudent <= _selectedStudents.Count)
        {
            return;
        }
        else
        {
            if (IsSelected(student))
            {
                _selectedStudents.Remove(student);
            }
            else
            {
                _selectedStudents.Add(student);
            }
            
            OnChangeStudent?.Invoke();
        }
    }
    
    // 학생 선택
    public void SelectRestaurant(Restaurant restaurant)
    {
        _selectedRestaurant = restaurant;
        OnChangeRestaurant?.Invoke();
    }
}
