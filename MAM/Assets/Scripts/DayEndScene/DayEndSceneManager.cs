using UnityEngine;
using UnityEngine.PlayerLoop;

public class DayEndSceneManager : ASceneManager<DayEndSceneManager>
{
    [SerializeField] DayEndTeamProjectProgressSetter _teamProjectProgressSetter;
    [SerializeField] DayEndSubmitButtonSetter _submitButtonSetter;
    
    public DayEndTeamProjectProgressSetter TeamProjectProgressSetter => _teamProjectProgressSetter;
    
    private void Start()
    {
        InitializeUI();
    }

    private void PlayCutScene()
    {
        GameManager.CutsceneManager.PlayCutscene(ECutsceneName.Sleep);
        GameManager.CutsceneManager.ActOnCutSceneEnd += OnCutSceneEnd;
    }

    private void OnCutSceneEnd()
    {
        DayEnd();
    }
    
    private void DayEnd()
    {
        _teamProjectProgressSetter.ApplyDayEnd();
    }

    private void InitializeUI()
    {
        InitializeTeamProjectProgressUI();
        InitializeSubmitButton();
    }

    private void InitializeTeamProjectProgressUI()
    {
        _teamProjectProgressSetter.Initialize();
    }
    
    private void InitializeSubmitButton()
    {
        _submitButtonSetter.Initialize();
    }
}
