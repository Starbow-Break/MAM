using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    [SerializeField] private List<Team> _teams = new List<Team>();

    public List<Team> Teams => _teams;

    public void Initialize()
    {
        GameManager.FlowManager.ActOnNewProjectStart += () => {_teams.Clear(); };
    }
    public void SetTeams(List<Team> teams)
    {
        _teams = teams;
    }

    public List<Team> GetTeams()
    {
        return _teams;
    }

    public Team GetTeam(Student student)
    {
        foreach (var team in _teams)
        {
            if (team.Member1 == student || team.Member2 == student)
                return team;
        }
        
        return null;
    }
}
