using UnityEngine;

public class CSharpMiniGameJudgeEffectSetter : MonoBehaviour
{
    [SerializeField] private JudgeEffectUpdater _updater;
    
    public void OnEnable()
    {
        CSharpMiniGame.Controller.OnJudge += (noteType, judge) => ShowEffect(noteType, judge);
    }

    public void OnDisable()
    {
        CSharpMiniGame.Controller.OnJudge -= (noteType, judge) => ShowEffect(noteType, judge);
    }

    public void Initialize()
    {
        _updater.SetSpriteEnabled(false);
    }
    
    public void ShowEffect(ENoteType noteType, EJudge judge)
    {
        if (!(judge == EJudge.None || judge == EJudge.Miss))
        {
            _updater.SetEffectPosition(judge);
            _updater.SetEffectSprite(noteType);
            _updater.Play();
        }
    }
}
