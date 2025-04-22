using System.Collections;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;    // 회전 속도

    private void Start()
    {
        StartCoroutine(RotateSequence());
    }

    private IEnumerator RotateSequence()
    {
        while (true)
        {
            float delta = _rotateSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, delta);
            yield return null;
        }
    }
}
