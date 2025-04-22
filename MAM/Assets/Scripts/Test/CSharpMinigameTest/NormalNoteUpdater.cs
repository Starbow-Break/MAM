using System.Collections;
using UnityEngine;

public class NormalNoteUpdater : ANoteUpdater
{
    protected override IEnumerator ActSequence()
    {
        float duration = 60f / _bpm;
        float currentTime = 0.0f;
        while (currentTime < duration * 2f)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = currentTime / duration;
            float value = MoveCurve(normalizedTime);
            transform.position = Vector3.LerpUnclamped(_destination, _arrival, value);
            yield return null;
        }
        
        Destroy(gameObject);
    }

    private float MoveCurve(float x)
    {
        return Mathf.Pow(x, 30);
    }
}
