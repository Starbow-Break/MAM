using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class DayEndSceneManager : ASceneManager<DayEndSceneManager>
{
    [SerializeField] DayEndTeamProjectProgressSetter _teamProjectProgressSetter;
    [SerializeField] DayEndSubmitButtonSetter _submitButtonSetter;
    
    public DayEndTeamProjectProgressSetter TeamProjectProgressSetter => _teamProjectProgressSetter;
    
    private void Start()
    {
        InitializeUI();
        PlayCutScene();
    }

    private void PlayCutScene()
    {
        GameManager.CutsceneManager.PlayCutscene(ECutsceneType.Sleep);
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
