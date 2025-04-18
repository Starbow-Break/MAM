using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    [SerializeField] private List<Team> _teams = new List<Team>();

    public void SetTeams(List<Team> teams)
    {
        _teams = teams;
    }

    public List<Team> GetTeams()
    {
        return _teams;
    }
}
