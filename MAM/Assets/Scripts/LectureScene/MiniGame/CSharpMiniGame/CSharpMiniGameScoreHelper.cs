using UnityEngine;

public static class CSharpMiniGameScoreHelper
{
    public static float GetTotalMaxWeight(ChartData chartData)
    {
        float result = 0f;
        
        foreach (var note in chartData.Notes)
        {
            result += note.Count * GetJudgeScoreWeight(EJudge.Perfect);
        }

        return result;
    }

    public static float GetJudgeScoreWeight(EJudge judge)
    {
        switch (judge)
        {
            case EJudge.Perfect:
                return 2;
            case EJudge.EarlyGood:
            case EJudge.LateGood:
                    return 1;
            default:
                return 0;
        }
    }
}
