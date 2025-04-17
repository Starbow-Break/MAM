using UnityEngine;

public static class TeamProjectProgressHelper
{
    private static float maxProgress = 100.0f;

    public static void ApplyDayEnd(Team team)
    {
        float addProgress = CalculateAddProgress(team);
        RaiseProgress(team, addProgress);
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
    
    private static void RaiseProgress(Team team, float addProgress)
    {
        team.ProjectProgress = Mathf.Clamp(team.ProjectProgress + addProgress, 0.0f, maxProgress);
    }
}
