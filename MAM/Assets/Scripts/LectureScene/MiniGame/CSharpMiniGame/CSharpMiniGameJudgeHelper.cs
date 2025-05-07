using UnityEngine;

public static class CSharpMiniGameJudgeHelper
{
    // 판정 범위
    private static readonly float[] _judgeRange = { 0.08f, 0.15f, 0.25f };

    public static EJudge Judge(float delta, bool isHit)
    {
        // 치면 안되는 노트에 대한 판정 처리
        if (!isHit)
        {
            if (Mathf.Abs(delta) < _judgeRange[0]) return EJudge.Miss;
            return delta > 0 ? EJudge.Perfect : EJudge.None;
        }

        // 쳐야하는 노트에 대한 판정처리
        if (Mathf.Abs(delta) < _judgeRange[0]) return EJudge.Perfect;

        if (Mathf.Abs(delta) < _judgeRange[1]) return delta > 0 ? EJudge.LateGood : EJudge.EarlyGood;

        if (Mathf.Abs(delta) < _judgeRange[2]) return delta > 0 ? EJudge.LateBad : EJudge.EarlyBad;

        return delta > 0 ? EJudge.Miss : EJudge.None;
    }
}