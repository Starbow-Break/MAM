using System.Collections;
using UnityEngine;

public class NormalNoteUpdater : ANoteUpdater
{
    protected override IEnumerator ActSequence()
    {
        float duration = 60f / _bpm;
        float currentTime = 0.0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / duration;
            float value = MoveCurve(normalizedTime);
            transform.position = Vector3.Lerp(_destination, _arrival, value);
            yield return null;
        }
    }

    private float MoveCurve(float x)
    {
        return Mathf.Pow(1.0f - Mathf.Cos(x / 2.0f * Mathf.PI), 5);
    }
}
