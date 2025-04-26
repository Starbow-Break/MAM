using System.Collections;
using UnityEngine;

public class PulseRotator : MonoBehaviour
{
    [SerializeField] private float rotateAngle; // 주기당 회전 각
    [SerializeField, Min(0)] private int pulseIntensity;  // 펄스 세기
    
    private float _period; // 주기
    private bool isFirstPriod = true;
    
    private void Start()
    {
        StartCoroutine(RotateSequence());
    }

    public void SetPeriod(float period)
    {
        _period = period;
    }

    private IEnumerator RotateSequence()
    {
        float currentTime = 0.0f;
        float beforeValue = 0.0f;
        
        while (true)
        {
            float offset = 0.0f;
            
            currentTime += Time.deltaTime;
            if (currentTime >= _period)
            {
                isFirstPriod = false;
                offset += rotateAngle * Mathf.Floor(currentTime / _period);
                currentTime %= _period;
            }
            
            float normalizedTime = currentTime / _period;
            float currentValue = RotateCurve(isFirstPriod, normalizedTime);
            
            float diff = offset + (currentValue - beforeValue) * rotateAngle;
            
            transform.rotation *= Quaternion.Euler(0, 0, diff);
            beforeValue = currentValue;

            yield return null;
        }
    }

    private float RotateCurve(bool isFirst, float x)
    {
        if (isFirst)
        {
            return ConstantCurve.PolyEaseIn(pulseIntensity, x);
        }

        return ConstantCurve.PolyEaseInOut(pulseIntensity, x);
    }
}
