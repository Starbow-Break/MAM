using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ReSharper disable All
public class TeamSelectSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _studentListUI; // 학생 목록 UI
    
    public int SelectedTeamId { get; private set; } = -1; // 현재 선택된 팀의 ID
    public Dictionary<int, Team> _teamDict { get; private set; } = new(); // 각 팀에 배정된 학생들
    public int RegisteredStudents { get; private set; }   // 팀에 들어간 학생 수

    public UnityAction OnChangeTeam { get; set; }
    public UnityAction OnChangeStudent { get; set; }

    public void Start()
    {
        _studentListUI.SetActive(false);
        RegisteredStudents = 0;
    }

    #region Query
    // 팀 반환
    public Team GetTeam(int teamId)
    {
         return _teamDict.ContainsKey(teamId) ? _teamDict[teamId] : null;
    }
    
    // 팀 리스트
    public List<Team> GetTeamList()
    {
        List<Team> teamList = new List<Team>();
        foreach (var teamPair in _teamDict)
        {
            teamList.Add(teamPair.Value);
        }
        return teamList;
    }
    
    // 팀에 가입한 상태인지 확인
    public bool IsRegistered(string targetId)
    {
        foreach(var teamPair in _teamDict)
        {
            Team currentTeam = teamPair.Value;
            List<Student> members = new List<Student> { currentTeam.Member1, currentTeam.Member2 };
            foreach(var member in members)
            {
                if(member != null && targetId == member.ID)
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    // 선택한 팀에 가입한 상태인지 확인
    public bool IsRegisteredSelectedTeam(string targetId)
    {
        var team = GetTeam(SelectedTeamId);
        List<Student> members = new List<Student> { team?.Member1, team?.Member2 };
        foreach(var member in members)
        {
            if(member != null && member.ID == targetId)
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    // 팀 선택
    public void SelectTeam(int teamNumber)
    { 
        if (!_teamDict.ContainsKey(teamNumber))
        {   
            Team newTeam = new Team();
            newTeam.TeamNumber = teamNumber;
            _teamDict.Add(teamNumber, newTeam);
        }
        
        SelectedTeamId = SelectedTeamId == teamNumber ? -1 : teamNumber;
        _studentListUI.SetActive(SelectedTeamId != -1);
        OnChangeTeam?.Invoke();
    }
    
    // 학생 선택
    public void SelectStudent(Student student)
    {
        int unregisteredStudentsBefore = RegisteredStudents;
        
        Team currentTeam = GetTeam(SelectedTeamId);
        if (currentTeam.Member1 == student)
        {
            currentTeam.Member1 = null;
            RegisteredStudents--;
            OnChangeStudent?.Invoke();
        }
        else if (currentTeam.Member2 == student)
        {
            currentTeam.Member2 = null;
            RegisteredStudents--;
            OnChangeStudent?.Invoke();
        }
        else
        {
            if (currentTeam.Member1 == null)
            {
                currentTeam.Member1 = student;
                RegisteredStudents++;
                OnChangeStudent?.Invoke();
            }
            else if (currentTeam.Member2 == null)
            {
                currentTeam.Member2 = student;
                RegisteredStudents++;
                OnChangeStudent?.Invoke();
            }
        }
    }
}
