using UnityEngine;
using System.Collections.Generic;
public class StudentManager : MonoBehaviour
{
    [SerializeField]private List<Student> _students = new List<Student>();

    public Student GetStudent(string ID)
    {
        return _students.Find(x => x.ID == ID);
    }

    public List<Student> GetStudents()
    {
        return _students;
    }
}
