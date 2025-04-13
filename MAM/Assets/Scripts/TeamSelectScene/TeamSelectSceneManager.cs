using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
public class TeamSelectSceneManager: MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TeamButtonSetter _teamButtonSetter;      // 팀 리스트 UI
    [SerializeField] private StudentButtonSetter _studentButtonSetter;   // 학생 리스트 UI
    [SerializeField] private StudentInfoSetter _studentInfoSetter;  // 학생 정보 UI
    [SerializeField] private TeamSelectSubmitButtonSetter _submitButtonSetter;  // 확인 버튼

    public static TeamSelectSceneManager Instance = null;

    public void Awake()
    {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

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
