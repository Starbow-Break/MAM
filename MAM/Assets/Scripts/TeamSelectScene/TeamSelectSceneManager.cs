using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// ReSharper disable All
public class TeamSelectSceneManager: ASceneManager<TeamSelectSceneManager>
{
    [SerializeField] private TeamSelectSceneController _controller;
    [SerializeField] private TeamSelectTeamButtonSetter _teamButtonSetter;      // 팀 리스트 UI
    [SerializeField] private TeamSelectStudentButtonSetter _studentButtonSetter;   // 학생 리스트 UI
    [SerializeField] private TeamSelectStudentInfoSetter _studentInfoSetter;  // 학생 정보 UI
    [SerializeField] private TeamSelectSubmitButtonSetter _submitButtonSetter;  // 확인 버튼

    [Header("Test Mode")]
    [SerializeField] private bool testMode = false;
    [SerializeField, Min(0)] private int studentShuffleCount = 20;

    public static TeamSelectSceneController Controller => Instance._controller;
    public static TeamSelectTeamButtonSetter TeamButtonSetter => Instance._teamButtonSetter;
    public static TeamSelectStudentButtonSetter StudentButtonSetter => Instance._studentButtonSetter;
    public static TeamSelectStudentInfoSetter StudentInfoSetter => Instance._studentInfoSetter;
    public static TeamSelectSubmitButtonSetter SubmitButtonSetter => Instance._submitButtonSetter;
    
    private void Start()
    {
        InitializeUI();
        if(testMode)
        {
            SetTestMode();
        }
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

    #region Test Mode
    private void SetTestMode()
    {
        RandomizeTeamSetting();
    }

    private void RandomizeTeamSetting()
    {
        List<Student> students = GameManager.StudentManager.GetStudents();
        int teamCount = students.Count / 2 + students.Count % 2;

        List<Student> shuffledStudent = new();
        foreach(Student student in students)
        {
            shuffledStudent.Add(student);
        }

        ListShuffler.Shuffle(shuffledStudent, studentShuffleCount);

        for(int i = 1; i <= teamCount; i++)
        {
            Controller.SelectTeam(i);
            Controller.SelectStudent(shuffledStudent[2 * i - 2]);
            Controller.SelectStudent(shuffledStudent[2 * i - 1]);
        }
    }
    #endregion
}
