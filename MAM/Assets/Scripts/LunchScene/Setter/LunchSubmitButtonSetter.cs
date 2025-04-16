using System;
using UnityEngine;

public class LunchSubmitButtonSetter : MonoBehaviour
{
    [SerializeField] private LunchSceneController _controller;
    [SerializeField] private LunchRestaurantButtonSetter _restaurantButtonSetter;
    [SerializeField] private SubmitButtonUpdater _updater;

    private void OnEnable()
    {
        _controller.OnChangeStudent += () => UpdateUI();
    }

    private void OnDisable()
    {
        _controller.OnChangeStudent -= () => UpdateUI();
    }

    public void Initialize()
    {
        _updater.SetInteractible(false);
        _updater.AddOnClickEventListener(() =>
        {
            Debug.Log(_restaurantButtonSetter.SelectedRestaurant.Name);
        });
    }

    private void UpdateUI()
    {
        _updater.SetInteractible(_controller.SelectedStudentCount > 0);
    }
}
