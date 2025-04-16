using UnityEngine;

public static class MBTIHelper
{
    public static int GetSynergyScore(string mbti1, string mbti2)
    {
        int score = 0;

        if (mbti1[0] == mbti2[0])
            score++;
        if (mbti1[1] != mbti2[1])
            score++;
        if (mbti1[2] != mbti2[2])
            score++;
        if (mbti1[3] == mbti2[3])
            score++;
        
        return score;
    }
}
