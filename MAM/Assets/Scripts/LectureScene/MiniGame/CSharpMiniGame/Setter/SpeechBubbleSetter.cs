using System.Collections;
using UnityEngine;

public class SpeechBubbleSetter : MonoBehaviour
{
    [SerializeField] SpeechBubbleUpdater _updater;

    private readonly string IfRed = "빨간색만";
    private readonly string IfBlue = "파란색만";
    private readonly string ForFormat = "{0}번!";

    private ENoteType _triggerNoteType = ENoteType.Normal;

    private void OnEnable()
    {
        CSharpMiniGame.VisualizeCountSetter.OnValueChanged += OnVisualizeCountSetterChanged;
        CSharpMiniGame.Controller.OnJudge += OnForNodeJudge;
    }

    private void OnDisable()
    {
        CSharpMiniGame.VisualizeCountSetter.OnValueChanged -= OnVisualizeCountSetterChanged;
        CSharpMiniGame.Controller.OnJudge += OnForNodeJudge;
    }

    public void Initialize()
    {
        _updater.SetActive(false);
    }
    
    public void Show(EventQueueData data)
    {
        _updater.SetActive(true);
        _triggerNoteType = data.NoteType;
        string text = "";
        if(data.NoteType == ENoteType.If)
        {
            if(data.Color == Color.red)
            {
                text = IfRed;
            }
            if(data.Color == Color.blue)
            {
                text = IfBlue;
            }
        }
        else if(data.NoteType == ENoteType.For)
        {
            text = string.Format(ForFormat, data.Count);
        }

        _updater.SetText(text);
    }

    public void Hide()
    {
        _updater.SetActive(false);
    }

    private void OnVisualizeCountSetterChanged(int value)
    {
        if(_triggerNoteType == ENoteType.If && value <= 0)
        {
            Hide();
        }
    }

    private void OnForNodeJudge(JudgeInfo judgeInfo)
    {
        if(_triggerNoteType == ENoteType.For && judgeInfo.NoteType == ENoteType.For)
        {
            Hide();
        }
    }
}
