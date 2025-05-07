using System.Collections;
using UnityEngine;

public class IfNoteUpdater : ANoteUpdater
{
    [SerializeField] private APeriodicRotator _rotator;
    [SerializeField] [Min(0)] private int _moveIntensity = 4;

    private void OnDisable()
    {
        _rotator.Stop();
    }

    public void SetColor(Color color)
    {
        ModelRenderer.color = color;
    }

    protected override IEnumerator ActSequence()
    {
        var noteQueue = CSharpMiniGameQueue.NoteQueue;
        noteQueue.Enqueue(this);

        PlayRotator();

        yield return MoveSequence(_arriveTime);
    }

    private void PlayRotator()
    {
        _rotator.SetPeriod(_arriveTime);
        _rotator.Play();
    }

    private IEnumerator MoveSequence(float duration)
    {
        var currentTime = 0.0f;
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= duration) SetActive(false);
            var normalizedTime = currentTime / duration;
            var value = MoveCurve(normalizedTime);
            transform.position = Vector3.LerpUnclamped(_destination, _arrival, value);
            yield return null;
        }
    }

    private float MoveCurve(float x)
    {
        return ConstantCurve.PolyEaseIn(_moveIntensity, x);
    }
}