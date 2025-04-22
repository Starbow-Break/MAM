using System.Collections.Generic;

public static class ListExtensions 
{
    private static System.Random _rng = new System.Random();

    //리스트섞기
    public static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]); // 바꾸기
        }
    }
}