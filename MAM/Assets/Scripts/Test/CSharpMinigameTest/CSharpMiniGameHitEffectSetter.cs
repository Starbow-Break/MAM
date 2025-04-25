using UnityEngine;
using UnityEngine.Serialization;

public class CSharpMiniGameHitEffectSetter : MonoBehaviour
{
    [SerializeField] HitEffectUpdater _updater;
    [SerializeField] private float fadeOutSpeed = 2f;
    
    private float alpha = 0f;
    
    public void OnEnable()
    {
        CSharpMiniGame.Input.OnKeyDown += () => SetAlpha(1f);
    }

    public void OnDisable()
    {
        CSharpMiniGame.Input.OnKeyDown += () => SetAlpha(0f);
    }
    
    public void Initialize()
    {
        SetAlpha(0f);
    }
    
    public void Update()
    {
        alpha  = Mathf.Clamp01(alpha - fadeOutSpeed * Time.deltaTime);
        _updater.SetAlpha(alpha);
    }

    public void SetAlpha(float a)
    {
        alpha = a;
    }
}
