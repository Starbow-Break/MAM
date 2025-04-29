using UnityEngine;

public class HitEffectUpdater : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();     
    }

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }
    
    public void SetAlpha(float a)
    {
        Color newColor = _renderer.color;
        newColor.a = a;
        _renderer.color = newColor;
    }
}
