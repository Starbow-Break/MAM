using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image _faderImage;
    
    private void Start()
    {
        Color color = _faderImage.color;
        _faderImage.color = new Color(color.r, color.g, color.b, 0);
        _faderImage.enabled = false;
    }
    public void FadeOut(float duration = 0.3f, Action callback = null)
    {
        StopAllCoroutines();
        _faderImage.enabled = true;
        StartCoroutine(FadeTo(duration, 1, callback));
    }
    
    public void FadeIn(float duration = 0.3f, Action callback = null)
    {
        StopAllCoroutines();
        callback += () =>
        {
            _faderImage.enabled = false;
        };
        StartCoroutine(FadeTo(duration, 0, callback));
    }
    
    private IEnumerator FadeTo(float duration, float targetAlpha, Action callback = null)
    {
        float time = 0f;
        float startAlpha = _faderImage.color.a;
        Color color = _faderImage.color;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / duration);
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t);
            _faderImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // 보정
        _faderImage.color = new Color(color.r, color.g, color.b, targetAlpha);
        callback?.Invoke();
    }
}
