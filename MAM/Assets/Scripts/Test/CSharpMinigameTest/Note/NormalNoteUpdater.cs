using System.Collections;
using UnityEngine;

public class NormalNoteUpdater : ANoteUpdater
{
    [SerializeField, Min(0)] private int _moveIntensity = 4;
    
    protected override IEnumerator ActSequence()
    {
        float duration = 60f / _bpm;
        yield return MoveSequence(duration);
        Destroy(gameObject);
    }

    private IEnumerator MoveSequence(float duration)
    {
        float currentTime = 0.0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / duration;
            float value = MoveCurve(normalizedTime);
            transform.position = Vector3.LerpUnclamped(_destination, _arrival, value);
            yield return null;
        }
    }

    private float MoveCurve(float x)
    {
        return ConstantCurve.PolyEaseIn(_moveIntensity, x);
    }
}
