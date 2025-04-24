using UnityEngine;

public static class ConstantCurve
{
    public static float PolyEaseIn(int intensity, float x)
    {
        float order = 2 * intensity + 1;
        return Mathf.Pow(x, order);
    }
    
    public static float PolyEaseInOut(int intensity, float x)
    {
        float order = 2 * intensity + 1;
        return (Mathf.Pow(2f * x - 1f, order) + 1f) / 2f;
    }
}
