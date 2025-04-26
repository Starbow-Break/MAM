using UnityEngine;

public class CSharpMiniGameJudgeEffectSetter : MonoBehaviour
{
    [SerializeField] private JudgeEffectUpdater _updater;
    
    public void OnEnable()
    {
        CSharpMiniGame.Controller.OnJudge += judgeInfo => ShowEffect(judgeInfo);
    }

    public void OnDisable()
    {
        CSharpMiniGame.Controller.OnJudge -= judgeInfo => ShowEffect(judgeInfo);
    }

    public void Initialize()
    {
        _updater.SetSpriteEnabled(false);
    }
    
    public void ShowEffect(JudgeInfo judgeInfo)
    {
        EJudge judge = judgeInfo.Judge;
        if (!(judge == EJudge.None || judge == EJudge.Miss))
        {
            _updater.SetEffectPosition(judge);
            _updater.SetEffectSprite(judgeInfo.NoteSprite);
            _updater.SetEffectColor(judgeInfo.NoteColor);
            _updater.SetEffectTransform(judgeInfo.NoteRotation, judgeInfo.NoteScale);
            _updater.Play();
        }
    }
}
