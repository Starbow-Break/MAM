using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeEffectUpdater : MonoBehaviour
{
    [System.Serializable]
    public struct JudgeEffectPoint
    {
        public EJudge judge;
        public Transform transform;
    }
    
    [System.Serializable]
    public struct JudgeEffectSprite
    {
        public ENoteType noteType;
        public Sprite sprite;
    }
    
    [SerializeField] private List<JudgeEffectPoint> _judgeEffectPoints;
    [SerializeField] private SpriteRenderer _objectRenderer;
    [SerializeField] private List<JudgeEffectSprite> _judgeEffectSprites;
    
    public void Play()
    {
        StartCoroutine(PlaySequence());
    }
    
    public void SetEffectPosition(EJudge judge)
    {
        foreach (var point in _judgeEffectPoints)
        {
            if (point.judge == judge)
            {
                _objectRenderer.transform.position = point.transform.position;
            }
        }
    }
    
    public void SetEffectSprite(ENoteType noteType)
    {
        foreach (var sprite in _judgeEffectSprites)
        {
            if (sprite.noteType == noteType)
            {
                _objectRenderer.sprite = sprite.sprite;
            }
        }
    }

    public void SetSpriteEnabled(bool enabled)
    {
        _objectRenderer.enabled = enabled;
    }

    private IEnumerator PlaySequence()
    {
        SetSpriteEnabled(true);
        
        float currentTime = 0f;
        float duration = 0.2f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float n = currentTime / duration;
            float value = 1f - Mathf.Abs(Mathf.Cos(n * Mathf.PI));
            _objectRenderer.transform.localScale = value * Vector3.one;
            yield return null;
        }
        
        SetSpriteEnabled(false);
    }
}
