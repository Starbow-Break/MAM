using System.Collections;
using UnityEngine;

public class IfNoteUpdater : ANoteUpdater
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] PulseRotator _rotator;
    [SerializeField, Min(0)] private int _moveIntensity = 4;
    
    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
    
    protected override IEnumerator ActSequence()
    {
        SetRotator();
        
        yield return MoveSequence(_lifeTime);
        Destroy(gameObject);
    }

    private void SetRotator()
    {
        _rotator.SetPeriod(_lifeTime);
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
        return ConstantCurve.PolyEaseIn(4, x);
    }
}
