using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeamSelectSceneController : MonoBehaviour
{
    private static readonly int MemberPerTeam = 2;  // 팀 당 인원 수

    [SerializeField] private GameObject _studentListUI; // 학생 목록 UI
    
    public int SelectedTeamId { get; private set; } = -1; // 현재 선택된 팀의 ID
    public Dictionary<int, string[]> _teamDict { get; private set; } = new(); // 각 팀에 배정된 학생들
    
    public UnityAction OnChangeTeam { get; set; }
    public UnityAction OnChangeStudent { get; set; }

    public void Start()
    {
        _studentListUI.SetActive(false);
    }

    #region Query
    // 팀에 속한 멤버 리스트 반환
    public string[] GetTeamMembers(int teamId)
    {
         return _teamDict.ContainsKey(teamId) ? _teamDict[teamId] : null;
    }

    public bool IsRegistered(string targetId)
    {
        foreach(var team in _teamDict)
        {
            foreach(string studentId in team.Value)
            {
                if(targetId == studentId)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsRegisteredSelectedTeam(string targetId)
    {
        var membersIds = GetTeamMembers(SelectedTeamId);
        foreach(var memberId in membersIds)
        {
            if(memberId == targetId)
            {
                if(targetId == memberId)
                {
                    return true;
                }
            }
        }
        return false;
    }
    #endregion

    // 팀 선택
    public void SelectTeam(int teamId)
    { 
        if (!_teamDict.ContainsKey(teamId))
        {   
            _teamDict.Add(teamId, new string[MemberPerTeam]);
        }
        
        SelectedTeamId = SelectedTeamId == teamId ? -1 : teamId;
        _studentListUI.SetActive(SelectedTeamId != -1);
        OnChangeTeam?.Invoke();
    }
    
    // 학생 선택
    public void SelectStudent(Student student)
    {
        int index = Array.IndexOf(_teamDict[SelectedTeamId], student.ID);
        if (index != -1)
        {
            _teamDict[SelectedTeamId][index] = null;
            OnChangeStudent?.Invoke();
        }
        else
        {
            for (int i = 0; i < MemberPerTeam; i++)
            {
                if (_teamDict[SelectedTeamId][i] == null)
                {
                    _teamDict[SelectedTeamId][i] = student.ID;
                    OnChangeStudent?.Invoke();
                    break;
                }
            }
        }
    }
}
