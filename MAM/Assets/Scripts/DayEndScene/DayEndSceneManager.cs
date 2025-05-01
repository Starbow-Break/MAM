using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class DayEndSceneManager : ASceneManager<DayEndSceneManager>
{
    [SerializeField] DayEndTeamProjectProgressSetter _teamProjectProgressSetter;
    [SerializeField] DayEndSubmitButtonSetter _submitButtonSetter;
    [FormerlySerializedAs("_calenderUpdater")] [SerializeField] CalendarUpdater calendarUpdater;
    
    public DayEndTeamProjectProgressSetter TeamProjectProgressSetter => _teamProjectProgressSetter;
    public CalendarUpdater CalendarUpdater => calendarUpdater;
    
    private void Start()
    {
        InitializeUI();
        PlayCutScene();
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
