using System.Collections;
using UnityEngine;

public abstract class ANoteUpdater : MonoBehaviour
{
    [Header("Model")]
    [field: SerializeField]
    public Transform ModelTransform { get; private set; }

    [field: SerializeField] 
    public SpriteRenderer ModelRenderer { get; private set; }
    
    protected float _arriveTime;
    protected Vector3 _destination;
    protected Vector3 _arrival;

    private bool needAct = false;

    private void OnEnable()
    {
        needAct = true;
    }

    private void Update()
    {
        if(needAct)
        {
            needAct = false;
            Act();
        }
    }

    private void Act()
    {
        StartCoroutine(ActSequence());
    }

    protected abstract IEnumerator ActSequence();

    protected virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    
    public void SetArriveTime(float arriveTime)
    {
        _arriveTime = arriveTime;
    }
    
    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
    }
    
    public void SetArrival(Vector3 arrival)
    {
        _arrival = arrival;
    }
}
