using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ForNoteUpdater : ANoteUpdater
{
    [SerializeField] TextMeshPro _countText;
    [SerializeField] PulseRotator _rotator;
    [SerializeField, Min(0)] private int _moveIntensity = 4;
    [SerializeField] private ForNoteBulletSpawner _bulletSpawner;
    [SerializeField] private float _bulletSpawnOffset = 0.1f;
    
    private int _count = 3; // 박자 

    protected override IEnumerator ActSequence()
    {
        SetRotators();
        
        while (_count > 0)
        {
            if (_count > 1)
            {
                yield return new WaitForSeconds(_lifeTime - _bulletSpawnOffset);
                float dist = (_arrival - _destination).magnitude;
                _bulletSpawner.SpawnBullet(dist / _bulletSpawnOffset, _bulletSpawnOffset);
                yield return new WaitForSeconds(_bulletSpawnOffset);
            }
            else
            {
                yield return MoveSequence(_lifeTime);
            }
            Discount();
        }
        
        Destroy(gameObject);
    }

    private void SetRotators()
    {
        _rotator.SetPeriod(_lifeTime);
    }
    
    protected IEnumerator MoveSequence(float duration)
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

    public void SetCount(int count)
    {
        _count = count;
        _countText.text = count.ToString();
    }

    public void Discount()
    {
        SetCount(_count - 1);
    }
}
