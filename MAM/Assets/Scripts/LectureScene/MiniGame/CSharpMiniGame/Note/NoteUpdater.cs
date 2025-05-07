using System.Collections;
using UnityEngine;

public abstract class ANoteUpdater : MonoBehaviour
{
    [Header("Model")]
    [field: SerializeField]
    public Transform ModelTransform { get; private set; }

    [field: SerializeField] public SpriteRenderer ModelRenderer { get; private set; }

    protected Vector3 _arrival;

    protected float _arriveTime;
    protected Vector3 _destination;
    private bool needAct;

    private Quaternion startModelRotation;
    private Vector3 startScale;

    private void Awake()
    {
        startModelRotation = ModelTransform.rotation;
        startScale = transform.lossyScale;
    }

    private void Start()
    {
        transform.localScale = startScale;
    }

    private void Update()
    {
        if (needAct)
        {
            needAct = false;
            Act();
        }
    }

    private void OnEnable()
    {
        ModelTransform.rotation = startModelRotation;
        needAct = true;
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