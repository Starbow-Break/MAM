using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeEffectUpdater : MonoBehaviour
{
    [SerializeField] private List<JudgeEffectPoint> _judgeEffectPoints;
    [SerializeField] private SpriteRenderer _objectRenderer;

    public void Play()
    {
        StartCoroutine(PlaySequence());
    }

    public void SetEffectPosition(EJudge judge)
    {
        foreach (var point in _judgeEffectPoints)
            if (point.judge == judge)
                _objectRenderer.transform.position = point.transform.position;
    }

    public void SetEffectSprite(Sprite sprite)
    {
        _objectRenderer.sprite = sprite;
    }

    public void SetSpriteEnabled(bool enabled)
    {
        _objectRenderer.enabled = enabled;
    }

    public void SetEffectTransform(Quaternion rotation, Vector3 scale)
    {
        _objectRenderer.transform.rotation = rotation;
        _objectRenderer.transform.localScale = scale;
    }

    public void SetEffectColor(Color color)
    {
        _objectRenderer.color = color;
    }

    private IEnumerator PlaySequence()
    {
        SetSpriteEnabled(true);

        var originLocalScale = _objectRenderer.transform.localScale;
        var currentTime = 0f;
        var duration = 0.2f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            var n = currentTime / duration;
            var value = 1f - Mathf.Abs(Mathf.Cos(n * Mathf.PI));
            _objectRenderer.transform.localScale = value * originLocalScale;
            yield return null;
        }

        SetSpriteEnabled(false);
    }

    [Serializable]
    public struct JudgeEffectPoint
    {
        public EJudge judge;
        public Transform transform;
    }
}