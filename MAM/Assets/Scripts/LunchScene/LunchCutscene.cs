using System.Collections.Generic;
using UnityEngine;

public class LunchCutscene : MonoBehaviour
{
    [SerializeField] private List<CutsceneActor> _students;

    private void OnEnable()
    {
        InactiveAllStudents();
        List<Student> students = LunchSceneManager.Controller.SelectedStudents;
        int count = Mathf.Min(students.Count, _students.Count);
        for (int i = 0; i < count; i++)
        {
            _students[i].gameObject.SetActive(true);
            _students[i].SetActor(students[i].ID);
        }
    }

    private void InactiveAllStudents()
    {
        foreach (var student in _students)
        {
            student.gameObject.SetActive(false);
        }
    }
}
