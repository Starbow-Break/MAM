using System.Collections;
using UnityEngine;

public abstract class ANoteUpdater : MonoBehaviour
{
    protected float _lifeTime;
    protected Vector3 _destination;
    protected Vector3 _arrival;

    public void SetLifeTime(float bpm)
    {
        _lifeTime = bpm;
    }
    
    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
    }
    
    public void SetArrival(Vector3 arrival)
    {
        _arrival = arrival;
    }
    
    private void Start()
    {
        Act();
    }

    private void Act()
    {
        StartCoroutine(ActSequence());
    }

    protected abstract IEnumerator ActSequence();
}
