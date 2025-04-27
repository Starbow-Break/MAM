using System.Collections;
using UnityEngine;

public abstract class APeriodicRotator : MonoBehaviour
{
    [SerializeField] private float rotateAngle; // 주기당 회전 각
    
    protected float _period; // 주기
    protected int loopCount = 0;    // 주기 횟수
    
    public void Play()
    {
        StartCoroutine(RotateSequence());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    public void SetPeriod(float period)
    {
        _period = period;
    }

    protected virtual IEnumerator RotateSequence()
    {
        float currentTime = 0.0f;
        float beforeValue = 0.0f;
        
        while (true)
        {
            float offset = 0.0f;
            
            currentTime += Time.deltaTime;

            int addLoop = Mathf.FloorToInt(currentTime / _period);
            loopCount += addLoop;
            offset += rotateAngle * addLoop;
            currentTime %= _period;
            
            float normalizedTime = currentTime / _period;
            float currentValue = RotateCurve(normalizedTime);
            
            float diff = offset + (currentValue - beforeValue) * rotateAngle;
            
            transform.rotation *= Quaternion.Euler(0, 0, diff);
            beforeValue = currentValue;

            yield return null;
        }
    }

    protected abstract float RotateCurve(float x);
}
