using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class StudentManager : MonoBehaviour
{
    [SerializeField] private StudentStartDataTable _startDataTable = null;
    [SerializeField] private List<Student> _students = new List<Student>();
    [SerializeField] private StudentCharacterGenerator _studentCharacterGenerator = null;

    public StudentCharacter GetStudentCharacter(string ID) => _studentCharacterGenerator.GetCharacter(ID);

    public void InitializeStudents()
    {
        _students.Clear();
        
        List<StudentStartData> startDatas = _startDataTable.StudentStartDataList;
        foreach (StudentStartData data in startDatas)
        {
            Student newStudent = new Student(data.ID);
            newStudent.Name = data.Name;
            newStudent.MBTI = data.MBTI;
            newStudent.SetSkillLevel(ESkillType.Unity, data.UnitySkill);
            newStudent.SetSkillLevel(ESkillType.CSharp, data.CSharpSkill);
            newStudent.FavRestaurant = data.FavRestaurant;
            newStudent.AffinityType = data.AffinityType;
            newStudent.Icon = data.Icon;
            
            _students.Add(newStudent);
        }
    }
    
    public Student GetStudent(string ID)
    {
        return _students.Find(x => x.ID == ID);
    }

    public List<Student> GetStudents()
    {
        return _students;
    }

    public int GetTotalStudentCount()
    {
        return _students.Count;
    }

    public List<string> GetStudentIds()
    {
        List<string> ids = new List<string>();
        foreach (var student in _students)
        {
            ids.Add(student.ID);
        }
        return ids;
    }
}
