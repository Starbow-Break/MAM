using System.Collections;
using TMPro;
using UnityEngine;

public class ForNoteUpdater : ANoteUpdater
{
    [SerializeField] TextMeshPro _countText;
    [SerializeField] APeriodicRotator _rotator;
    [SerializeField, Min(0)] private int _moveIntensity = 4;
    [SerializeField] private ForNoteBulletSpawner _bulletSpawner;
    
    private int _count = 3; // 박자

    protected override IEnumerator ActSequence()
    {
        PlayRotator();
        
        while (_count > 0)
        {
            if (_count > 1)
            {
                _bulletSpawner.SpawnBullet(_arrival, _arriveTime);
                yield return new WaitForSeconds(_arriveTime);
            }
            else
            {
                var noteQueue = CSharpMiniGameQueue.NoteQueue;
                noteQueue.Enqueue(this);
                yield return MoveSequence(_arriveTime);
            }
            Discount();
        }
    }

    private void PlayRotator()
    {
        _rotator.SetPeriod(_arriveTime);
        _rotator.Play();
    }
    
    protected IEnumerator MoveSequence(float duration)
    {
        float currentTime = 0.0f;
        
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= duration)
            {
                SetActive(false);
            }
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
