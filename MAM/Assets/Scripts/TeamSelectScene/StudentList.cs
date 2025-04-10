using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentList : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _studentButton;
    
    public void SetStudent(List<DummyStudentData> studentDatas)
    {
        foreach (DummyStudentData studentData in studentDatas)
        {
            GameObject spawnedStudentButton = Instantiate(_studentButton, _content);
            spawnedStudentButton.GetComponent<Image>().color = studentData.Color;
        }
    }
}
