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

    private Quaternion startModelRotation;
    private Vector3 startScale;
    private bool needAct = false;

    private void Awake()
    {
        startModelRotation = ModelTransform.rotation;
        startScale = transform.localScale;
    }

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
        ModelTransform.rotation = startModelRotation;
        transform.localScale = startScale;
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
