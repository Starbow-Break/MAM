using System;
using UnityEngine;
using Random = UnityEngine.Random;


//학생들 스텟 올려주는 클래스
public static class StudentLevelHelper
{
    #region c#,유니티

    private static readonly float[] _gainMultiPlier = { 1.0f, 0.5f, 0.25f };
    private const int _maxLevel = 6;


    /// <returns> 바뀐 능력치 리턴</returns>
    public static float ApplyMiniGameScore(Student student,ESkillType skillType, int miniGameScore, int miniGameDifficulty)
    {
        float skillLevel = student.GetSkillLevel(skillType);
        float newSkillLevel = GetRaisedSkillLevel(skillLevel, miniGameScore, miniGameDifficulty);   
        student.SetSkillLevel(skillType, newSkillLevel);
        
        return newSkillLevel;
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
    private static float _baseIntimacy = 20f;
    
    private static Tuple<float, float> notMatchRange = new (0.9f, 1.1f);
    private static Tuple<float, float> matchRange = new (1.2f, 1.5f);

    public static float ApplyLunch(Student student, Restaurant restaurant)
    {
        float newIntimacy = GetRaisedIntimacy(student, restaurant);
        student.Intimacy = newIntimacy;
        return newIntimacy;
    }
    
    public static float GetRaisedIntimacy(Student student, Restaurant restaurant)
    {
        bool favMatch = student.FavRestaurant == restaurant?.Name;
        Tuple<float, float> multiplierRange = favMatch ? matchRange : notMatchRange;
        float multiplier = Random.Range(multiplierRange.Item1, multiplierRange.Item2);
        float addIntimacy = _baseIntimacy * multiplier;
        float result = Mathf.Clamp(student.Intimacy + addIntimacy, 0f, _maxIntimacy);
        return result;
    }
    #endregion

    #region 의욕

    private static float _maxMotivation = 5.0f;
    private static float _minMotivation = 1.0f;

    private static float _randomAdjustMotivation = 0.5f;
    public static void ApplySelfStudyInteraction(Student student, EAffinityType actionType)
    {
        if (student.AffinityType == actionType)
        {
            student.Motivation = Mathf.Clamp(student.Motivation + 1, _minMotivation, _maxMotivation);
            return;
        }

        student.Motivation = Mathf.Clamp(student.Motivation - 1, _minMotivation, _maxMotivation);
    }

    public static void ApplyRandomMotivation(Student student)
    {
        if (Random.value < 0.5f)
        {
            student.Motivation = Mathf.Clamp(student.Motivation + _randomAdjustMotivation, _minMotivation, _maxMotivation);
            return;
        }
        
        student.Motivation = Mathf.Clamp(student.Motivation - _randomAdjustMotivation, _minMotivation, _maxMotivation);
    }
    
    #endregion
}
