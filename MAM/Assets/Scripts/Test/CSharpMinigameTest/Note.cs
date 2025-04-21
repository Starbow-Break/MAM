using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ANoteUpdater : MonoBehaviour
{
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
