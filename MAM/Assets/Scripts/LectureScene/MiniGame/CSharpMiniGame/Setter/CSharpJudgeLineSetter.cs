using UnityEngine;

public class CSharpJudgeLineSetter : MonoBehaviour
{

    [SerializeField] private JudgeLineUpdater _updater;
    [SerializeField] private Color _defaultColor;

    private void OnEnable()
    {
        CSharpMiniGame.VisualizeCountSetter.OnValueChanged += value => OnVisualizeCountValueChanged(value);
    }

    private void OnDisable()
    {
        CSharpMiniGame.VisualizeCountSetter.OnValueChanged -= value => OnVisualizeCountValueChanged(value);
    }

    public void Initialize()
    {
        SetDefaultColor();
    }

    public void SetColor(Color color)
    {
        _updater.SetLineColor(color);
    }

    private void OnVisualizeCountValueChanged(int value)
    {
        if (value <= 0)
        {
            SetDefaultColor();
        }
    }

    private void SetDefaultColor()
    {
        SetColor(_defaultColor);
    }
}
