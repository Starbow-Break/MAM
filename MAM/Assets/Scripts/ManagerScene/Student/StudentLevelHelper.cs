using UnityEngine;

public static class StudentLevelHelper
{
    private static readonly float[] _gainMultiPlier = { 1.0f, 0.5f, 0.25f };
    private const int _maxLevel = 6;

    public static void ApplyMiniGameScoreUnity(Student student, int miniGameScore, int miniGameDifficulty)
    {
        float newSkillLevel = GetRaisedSkillLevel(student.UnitySkill, miniGameScore, miniGameDifficulty);   
        student.UnitySkill = newSkillLevel;
    }

    public static void ApplyMiniGameScoreCSharp(Student student, int miniGameScore, int miniGameDifficulty)
    {
        float newSkillLevel = GetRaisedSkillLevel(student.CSharpSkill, miniGameScore, miniGameDifficulty);   
        student.CSharpSkill = newSkillLevel;
    }
    
    private static float GetRaisedSkillLevel(float studentSkillLevel, int miniGameScore, int miniGameDifficulty)
    {
        float baseGain = miniGameScore / 100f;
        int studentSkillLevelInt = Mathf.FloorToInt(studentSkillLevel);
        
        int distance = Mathf.Abs(GetRecommendedDifficulty(studentSkillLevelInt) - miniGameDifficulty);

        float gainMultiplier = _gainMultiPlier[distance];
        
        float totalGain = baseGain * gainMultiplier;
        
        return Mathf.Min(studentSkillLevel + totalGain, _maxLevel);
    }
    
    private static int GetRecommendedDifficulty(int studentSkillLevel)
    {
        switch (studentSkillLevel)
        {
            case 1: return 1;
            case 2: return 1;
            case 3: return 2;
            case 4: return 2;
            case 5: return 3;
            case 6: return 3;
            default: return 1;
        }
    }
}
