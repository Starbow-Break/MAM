using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// ReSharper disable All
public class TeamSelectSceneManager : MonoBehaviour
{
    [FormerlySerializedAs("_teamList")]
    [Header("UI")] 
    [SerializeField] private TeamButtonSetter _teamButtonSetter;      // 팀 리스트 UI
    [SerializeField] private StudentButtonSetter _studentButtonSetter;   // 학생 리스트 UI
    [SerializeField] private GameObject _studentInfo;   // 학생 정보 UI
    
    public void Start()
    {
        InitializeUI();
    }
    
    // UI 초기화
    private void InitializeUI()
    {
        // 팀 버튼 생성
        InitializeTeamListUI();
        // 학생 목록 생성
        InitializeStudentListUI();
    }

    private void InitializeTeamListUI()
    {
        List<Student> students = GameManager.StudentManager.GetStudents();
        int buttonCount = students.Count / 2 + students.Count % 2;
        _teamButtonSetter.Initialize(buttonCount);
    }

    private void InitializeStudentListUI()
    {
        // 학생 목록 불러오기
        List<Student> students = GameManager.StudentManager.GetStudents();
        _studentButtonSetter.Initialize(students);
    }
}
