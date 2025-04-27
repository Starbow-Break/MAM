using UnityEngine;

public class IfNoteRotator : APeriodicRotator
{
    [SerializeField, Min(0)] private int _intensity;  // 세기

    protected override float RotateCurve(float x)
    {
        return ConstantCurve.PolyEaseIn(_intensity, x);
    }
}
