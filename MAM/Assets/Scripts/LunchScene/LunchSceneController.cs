using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LunchSceneController : MonoBehaviour
{
    [SerializeField, Min(1)] private int _maxSelectedStudent = 6;   // 최대로 선택 가능한 학생 수

    private List<Student> _selectedStudent = new List<Student>();
    
    public UnityAction OnChangeStudent { get; set; }

    public int MaxSelectedStudent {
        get { return _maxSelectedStudent; }
    }

    public int SelectedStudentCount
    {
        get { return _selectedStudent.Count; }
    }

    #region Query

    public bool IsSelected(Student student)
    {
        return _selectedStudent.Contains(student);
    }
    #endregion
    
    // 학생 선택
    public void SelectStudent(Student student)
    {
        if (_maxSelectedStudent <= _selectedStudent.Count)
        {
            return;
        }
        else
        {
            if (IsSelected(student))
            {
                _selectedStudent.Remove(student);
            }
            else
            {
                _selectedStudent.Add(student);
            }
            
            OnChangeStudent?.Invoke();
        }
    }
}
