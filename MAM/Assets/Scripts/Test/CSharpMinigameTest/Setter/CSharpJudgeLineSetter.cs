using UnityEngine;

public class CSharpJudgeLineSetter : MonoBehaviour
{

    [SerializeField] private JudgeLineUpdater _updater;
    [SerializeField] private Color _defaultColor;

    private void OnEnable()
    {
        CSharpMiniGame.Controller.OnJudge += judgeInfo => TrySetDefault(judgeInfo);
    }

    private void OnDisable()
    {
        CSharpMiniGame.Controller.OnJudge -= judgeInfo => TrySetDefault(judgeInfo);
    }

    public void Initialize()
    {
        SetDefaultColor();
    }

    public void SetColor(Color color)
    {
        _updater.SetLineColor(color);
    }

    public void SetDefaultColor()
    {
        SetColor(_defaultColor);
    }

    private void TrySetDefault(JudgeInfo judgeInfo)
    {
        if(CSharpMiniGame.VisualizeCountSetter.Value == 0)
        {
            SetDefaultColor();
        }
    }
}
