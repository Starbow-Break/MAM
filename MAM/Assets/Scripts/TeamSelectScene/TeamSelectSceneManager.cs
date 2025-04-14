using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
public class TeamSelectSceneManager: ASceneManager<TeamSelectSceneManager>
{
    [Header("UI")] 
    [SerializeField] private TeamSelectTeamButtonSetter _teamButtonSetter;      // 팀 리스트 UI
    [SerializeField] private TeamSelectStudentButtonSetter _studentButtonSetter;   // 학생 리스트 UI
    [SerializeField] private TeamSelectStudentInfoSetter _studentInfoSetter;  // 학생 정보 UI
    [SerializeField] private TeamSelectSubmitButtonSetter _submitButtonSetter;  // 확인 버튼

    private void Start()
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
        // 학생 정보 초기화
        InitializeStudentInfoUI();
        // 확인 버튼 초기화
        InitializeSubmitButton();
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

    private void InitializeStudentInfoUI()
    {
        _studentInfoSetter.Initialize();
    }

    private void InitializeSubmitButton()
    {
        _submitButtonSetter.Initialize();
    }
}
