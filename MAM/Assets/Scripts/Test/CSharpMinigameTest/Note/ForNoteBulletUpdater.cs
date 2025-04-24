using System.Collections;
using UnityEngine;

public class ForNoteBulletUpdater : MonoBehaviour
{
    private Vector3 _destination;
    private Vector3 _arrival;
    
    private bool _isShot = false;
    private float _speed;
    private float _lifeTime = 1.0f;

    private void Start()
    {
        StartCoroutine(MoveSequence(_lifeTime));
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetLifeTime(float lifeTime)
    {
        _lifeTime = lifeTime;
    }

    private IEnumerator MoveSequence(float duration)
    {
        float currentTime = 0.0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject);
    }
}
