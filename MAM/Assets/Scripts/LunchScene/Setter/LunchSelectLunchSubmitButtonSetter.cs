using System;
using UnityEngine;

public class LunchSelectLunchSubmitButtonSetter : MonoBehaviour
{
    [SerializeField] private SubmitButtonUpdater _updater;

    private void OnEnable()
    {
        LunchSceneManager.Controller.OnChangeRestaurant += () => UpdateUI();
        LunchSceneManager.Controller.OnChangeStudent += () => UpdateUI();
    }

    private void OnDisable()
    {
        LunchSceneManager.Controller.OnChangeRestaurant -= () => UpdateUI();
        LunchSceneManager.Controller.OnChangeStudent -= () => UpdateUI();
    }

    public void Initialize()
    {
        _updater.SetInteractible(false);
        _updater.AddOnClickEventListener(() => OnClick());
    }

    private void UpdateUI()
    {
        int selectedStudentCount = LunchSceneManager.Controller.SelectedStudentCount;
        var selectedRestaurant = LunchSceneManager.Controller.SelectedRestaurant;
        _updater.SetInteractible(selectedRestaurant != null && selectedStudentCount > 0);
    }
    
    private void OnClick()
    {
        GameManager.CutsceneManager.PlayCutscene(ECutsceneName.Lunch);
        GameManager.CutsceneManager.ActOnCutSceneEnd += OnEndCutscene;
    }

    private void OnEndCutscene()
    {
        var targetUIType = LunchSceneManager.EUIObjectType.Raise_Intimacy;
        LunchSceneManager.Instance.SetUiObjects(targetUIType);
        LunchSceneManager.Controller.ApplyLunch();
    }
}
