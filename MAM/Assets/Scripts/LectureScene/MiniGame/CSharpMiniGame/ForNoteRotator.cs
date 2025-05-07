using UnityEngine;

public class ForNoteRotator : APeriodicRotator
{
    [SerializeField] [Min(0)] private int _intensity; // 세기

    protected override float RotateCurve(float x)
    {
        if (loopCount == 0) return 0.5f + ConstantCurve.PolyEaseIn(_intensity, x);

        return ConstantCurve.PolyEaseInOut(_intensity, x);
    }
}