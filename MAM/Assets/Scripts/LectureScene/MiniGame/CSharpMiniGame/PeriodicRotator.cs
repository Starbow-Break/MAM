using System.Collections;
using UnityEngine;

public abstract class APeriodicRotator : MonoBehaviour
{
    [SerializeField] private float rotateAngle; // 주기당 회전 각

    protected float _period; // 주기
    protected int loopCount; // 주기 횟수

    public void Play()
    {
        StartCoroutine(RotateSequence());
    }

    public void Stop()
    {
        loopCount = 0;
        StopAllCoroutines();
    }

    public void SetPeriod(float period)
    {
        _period = period;
    }

    protected virtual IEnumerator RotateSequence()
    {
        var currentTime = 0.0f;
        var beforeValue = 0.0f;

        while (true)
        {
            var offset = 0.0f;

            currentTime += Time.deltaTime;

            var addLoop = Mathf.FloorToInt(currentTime / _period);
            loopCount += addLoop;
            offset += rotateAngle * addLoop;
            currentTime %= _period;

            var normalizedTime = currentTime / _period;
            var currentValue = RotateCurve(normalizedTime);

            var diff = offset + (currentValue - beforeValue) * rotateAngle;

            transform.rotation *= Quaternion.Euler(0, 0, diff);
            beforeValue = currentValue;

            yield return null;
        }
    }

    protected abstract float RotateCurve(float x);
}