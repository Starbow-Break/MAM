using UnityEngine;
using UnityEngine.Serialization;

public class CSharpMiniGameHitEffectSetter : MonoBehaviour
{
    [SerializeField] HitEffectUpdater _updater;
    [SerializeField] private Color _color; 
    [SerializeField] private float _fadeOutSpeed = 2f;
    
    private float alpha = 0f;
    private float maxAlpha;
    
    public void OnEnable()
    {
        CSharpMiniGame.Input.OnKeyDown += () => SetAlpha(maxAlpha);
    }

    public void Start()
    {
        maxAlpha = _color.a;
    }

    public void OnDisable()
    {
        CSharpMiniGame.Input.OnKeyDown += () => SetAlpha(0f);
    }
    
    public void Initialize()
    {
        Color color = _color;
        color.a = 0f;
        _updater.SetColor(color);
    }
    
    public void Update()
    {
        alpha  = Mathf.Clamp01(alpha - _fadeOutSpeed * Time.deltaTime);
        _updater.SetAlpha(alpha);
    }

    public void SetAlpha(float a)
    {
        alpha = a;
    }
}
