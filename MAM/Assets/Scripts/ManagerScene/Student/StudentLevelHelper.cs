using UnityEngine;


//학생들 스텟 올려주는 클래스
public static class StudentLevelHelper
{
    #region c#,유니티

    private static readonly float[] _gainMultiPlier = { 1.0f, 0.5f, 0.25f };
    private const int _maxLevel = 6;

    public static void ApplyMiniGameScore(Student student,ESkillType skillType, int miniGameScore, int miniGameDifficulty)
    {
        float skillLevel = student.GetSkillLevel(skillType);
        float newSkillLevel = GetRaisedSkillLevel(skillLevel, miniGameScore, miniGameDifficulty);   
        student.SetSkillLevel(skillType,newSkillLevel);
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

    #endregion

    #region 친밀도
    private static float _maxIntimacy = 100f;

    public static void RaiseIntimacy(Student student, float addValue)
    {
        student.Intimacy = Mathf.Clamp(student.Intimacy + addValue, 0, _maxIntimacy);
    }
    #endregion

}
