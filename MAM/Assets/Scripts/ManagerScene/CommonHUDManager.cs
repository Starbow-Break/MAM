using System;
using UnityEngine;

public class CommonHUDManager : MonoBehaviour
{
    [SerializeField] private ScreenFader _fader = null;
    [SerializeField] private CommonHUDUpdater _updater = null;
    public void FadeIn(float duration = 0.3f, Action callback = null) => _fader.FadeIn(duration, callback);
    public void FadeOut(float duration = 0.3f, Action callback = null) => _fader.FadeOut(duration, callback);
    
    private void Start()
    {
        _updater.gameObject.SetActive(false);
    }
    public void Initialize()
    {
        GameManager.FlowManager.ActOnNewDayStart += SetHUDDay;
        GameManager.FlowManager.ActOnNewProjectStart += SetProjectNumber;
        
        _updater.gameObject.SetActive(true);
        SetHUDDay();
        SetProjectNumber();
    }

    private void SetHUDDay()
    {
        int day = GameManager.FlowManager.CurrentDay;
        _updater.SetDayText(day);
    }

    private void SetProjectNumber()
    {
        int project = GameManager.FlowManager.CurrentProject;
        _updater.SetProjectText(project);
        int day = GameManager.FlowManager.CurrentDay;
        _updater.SetDayText(day);
    }

    public void SetSceneName(string sceneName)
    {
        _updater.SetSceneNameText(sceneName);
    }
    
    public void HideHUD()
    {
        _updater.gameObject.SetActive(false);
    }

    public void ShowHUD()
    {
        _updater.gameObject.SetActive(true);
    }
    
}
