using System.Collections.Generic;
using UnityEngine;

public class LunchSceneManager : ASceneManager<LunchSceneManager>
{
    [SerializeField] private LunchStudentButtonSetter _studentButtonSetter;
    [SerializeField] private LunchStudentInfoSetter _studentinfoSetter;
    [SerializeField] private LunchSubmitButtonSetter _submitButtonSetter;

    public void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        // 학생 버튼 UI 초기화
        InitializeStudentButtonUI();
        // 학생 정보 초기화
        InitializeStudentInfoUI();
        // 확인 버튼 초기화
        InitializeSubmitButton();
    }
    
    private void InitializeStudentButtonUI()
    {
        List<Student> students = GameManager.StudentManager.GetStudents();
        _studentButtonSetter.Initialize(students);
    }

    private void InitializeStudentInfoUI()
    {
        _studentinfoSetter.Initialize();
    }

    private void InitializeSubmitButton()
    {
        _submitButtonSetter.Initialize();
    }
}
