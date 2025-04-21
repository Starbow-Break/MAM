using UnityEngine;

public class TeamGradeButtonViewer
{
    private TeamGradeButtonUpdater _updater;
    private Team _team;
    
    public Team Team => _team;

    public void Initialize(TeamGradeButtonUpdater updater, Team team)
    {
        _updater = updater;
        _team = team;
        
        _updater.SetTeam(team);
        _updater.SetTeamName($"Team {team.TeamNumber}");

        float goal = GameManager.FlowManager.GetCurrentProjectGoal;
        string grade = TeamProjectProgressHelper.ProgressToGrade(team, goal);
        _updater.SetGrade(grade);
    }

    public void ShowButton()
    {
        _updater.gameObject.SetActive(true);
    }
}
