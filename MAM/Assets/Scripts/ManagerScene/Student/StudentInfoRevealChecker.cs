using UnityEngine;

//친밀도에따른 정보 공개
public static class StudentInfoRevealChecker
{
    private static readonly float[] _intimacyCutLine = {25.0f,50.0f,75.0f,100.0f};

    //친밀도 1단계 25
    public static bool CheckMBTIReveal(Student student)
    {
        return student.Intimacy >= _intimacyCutLine[0];
    }

    //친밀도 2단계 50
    public static bool CheckFavRestaurantReveal(Student student)
    {
        return student.Intimacy >= _intimacyCutLine[1];
    }

    //친밀도 3단계 75
    public static bool CheckAffinityTypeReveal(Student student)
    {
        return student.Intimacy >= _intimacyCutLine[2];
    }

    //친밀도 4단계 100 (소수점버림)
    public static bool CheckMotivationReveal(Student student)
    {
        return student.Intimacy >= _intimacyCutLine[3];
    }
}
