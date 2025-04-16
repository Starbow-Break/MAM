using System;
using UnityEngine;

public class LunchSubmitButtonSetter : MonoBehaviour
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
        _updater.AddOnClickEventListener(() =>
        {
            var selectedRestaurant = LunchSceneManager.Controller.SelectedRestaurant;
            Debug.Log(selectedRestaurant?.Name);
        });
    }

    private void UpdateUI()
    {
        int selectedStudentCount = LunchSceneManager.Controller.SelectedStudentCount;
        var selectedRestaurant = LunchSceneManager.Controller.SelectedRestaurant;
        _updater.SetInteractible(selectedRestaurant != null && selectedStudentCount > 0);
    }
}
