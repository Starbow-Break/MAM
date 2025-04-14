using UnityEngine;

//친밀도에따른 정보 공개
public static class StudentInfoDisplayer
{
    private static readonly float[] _intimacyCutLine = {25.0f,50.0f,75.0f,100.0f};
    private static string _unrevealedDisplayString = "???";

    //친밀도 1단계 25
    public static string GetMBTI(Student student)
    {
        if (student.Intimacy >= _intimacyCutLine[0])
            return student.MBTI;
        
        return _unrevealedDisplayString;
    }

    //친밀도 2단계 50
    public static string GetFavRestaurant(Student student)
    {
        if (student.Intimacy >= _intimacyCutLine[1])
            return student.FavRestaurant;
        
        return _unrevealedDisplayString;
    }

    //친밀도 3단계 75
    public static string GetAffinityType(Student student)
    {
        if (student.Intimacy >= _intimacyCutLine[2])
            return student.AffinityType.ToString();
        
        return _unrevealedDisplayString;
    }

    //친밀도 4단계 100 (소수점버림)
    public static string GetMotivation(Student student)
    {
        if (student.Intimacy >= _intimacyCutLine[3])
            return ((int)student.Motivation).ToString();
        
        return _unrevealedDisplayString;
    }
    
}
