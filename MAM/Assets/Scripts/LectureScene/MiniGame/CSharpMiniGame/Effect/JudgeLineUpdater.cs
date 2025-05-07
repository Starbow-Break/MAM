using UnityEngine;

public class JudgeLineUpdater : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    public void SetLineColor(Color color)
    {
        var gradient = new Gradient();
        gradient.SetKeys(
            new[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
            new[] { new GradientAlphaKey(color.a, 0.0f), new GradientAlphaKey(color.a, 1.0f) }
        );
        _lineRenderer.colorGradient = gradient;
    }
}