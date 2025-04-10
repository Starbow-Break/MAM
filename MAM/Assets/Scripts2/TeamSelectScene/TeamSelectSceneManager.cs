using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
public class TeamSelectSceneManager : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TeamList _teamList;      // 팀 리스트 UI
    [SerializeField] private StudentList _studentList;   // 학생 리스트 UI
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
        _teamList.SetTeamNumber(10);
    }

    private void InitializeStudentListUI()
    {
        // 학생 목록 불러오기
        List<DummyStudentData> studentDatas = DummyStudentDataManager.Instance.GetStudentDatas();
        _studentList.SetStudent(studentDatas);
    }
}
