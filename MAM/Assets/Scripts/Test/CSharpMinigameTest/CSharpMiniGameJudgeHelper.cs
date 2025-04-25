using UnityEngine;

public static class CSharpMiniGameJudgeHelper
{
    // 판정 범위
    private static readonly float[] _judgeRange = { 0.08f, 0.15f, 0.25f };

    public static EJudge Judge(float delta)
    {
        if (Mathf.Abs(delta) < _judgeRange[0])
        {
            return EJudge.Perfect;
        }
        else if (Mathf.Abs(delta) < _judgeRange[1])
        {
            return delta > 0 ? EJudge.LateGood : EJudge.EarlyGood;
        }
        else if (Mathf.Abs(delta) < _judgeRange[2])
        {
            return delta > 0 ? EJudge.LateBad : EJudge.EarlyBad;
        }
        
        return delta > 0 ? EJudge.Miss : EJudge.None;
    }
}
