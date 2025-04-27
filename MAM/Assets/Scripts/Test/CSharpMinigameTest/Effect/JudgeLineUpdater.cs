using UnityEngine;

public class JudgeLineUpdater : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    public void SetLineColor(Color color)
    {
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(color.a, 0.0f), new GradientAlphaKey(color.a, 1.0f) }
        );
        _lineRenderer.colorGradient = gradient;
    }
}
