using UnityEngine;
using System.Collections.Generic;

public static class TeamProjectProgressHelper
{
    private static float maxProgress = 100.0f;

    public static float ApplyDayEnd(Team team)
    {
        float newProgress = GetRaisedTeamProjectProgress(team);
        team.ProjectProgress = newProgress;
        return newProgress;
    }
    
    private static float GetRaisedTeamProjectProgress(Team team)
    {
        float addProgress = CalculateAddProgress(team);
        return Mathf.Clamp(team.ProjectProgress + addProgress, 0, maxProgress);
    }

    private static float CalculateAddProgress(Team team)
    {
        float mbti = MBTIHelper.GetSynergyScore(team.Member1.MBTI, team.Member2.MBTI);
        float motivation = team.Member1.Motivation + team.Member2.Motivation;
        float help = 0; // 프로젝트 헬프 (반영 예정)
        float skill = CalculateSkillScore(team.Member1) + CalculateSkillScore(team.Member2);

        return mbti + motivation + help + skill;
    }

    private static float CalculateSkillScore(Student student)
    {
        float maxSkill = Mathf.Max(student.UnitySkill, student.CSharpSkill);
        float minSkill = Mathf.Min(student.UnitySkill, student.CSharpSkill);
        return maxSkill + minSkill / 2f;
    }

    
    #region Grade
    private static readonly List<KeyValuePair<float, string>> gradeThresholds = new()
    {
        new(1.0f, "A"),
        new(0.9f, "B"),
        new(0.75f, "C"),
        new(0.65f, "D"),
    };

    public static string ProgressToGrade(Team team, float goalProgress)
    {
        float ratio = team.ProjectProgress / goalProgress;

        foreach (var threshold in gradeThresholds)
        {
            if (ratio >= threshold.Key)
                return threshold.Value;
        }
        
        return "F";
    }
    #endregion
}
