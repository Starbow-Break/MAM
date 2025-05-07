using UnityEngine;

public class CSharpMiniGameHitEffectSetter : MonoBehaviour
{
    [SerializeField] private HitEffectUpdater _updater;
    [SerializeField] private Color _color;
    [SerializeField] private float _fadeOutSpeed = 2f;

    private float alpha;
    private float maxAlpha;

    public void Start()
    {
        maxAlpha = _color.a;
    }

    public void Update()
    {
        alpha = Mathf.Clamp01(alpha - _fadeOutSpeed * Time.deltaTime);
        _updater.SetAlpha(alpha);
    }

    public void OnEnable()
    {
        CSharpMiniGame.Input.OnKeyDown += () => SetAlpha(maxAlpha);
    }

    public void OnDisable()
    {
        CSharpMiniGame.Input.OnKeyDown += () => SetAlpha(0f);
    }

    public void Initialize()
    {
        var color = _color;
        color.a = 0f;
        _updater.SetColor(color);
    }

    public void SetAlpha(float a)
    {
        alpha = a;
    }
}