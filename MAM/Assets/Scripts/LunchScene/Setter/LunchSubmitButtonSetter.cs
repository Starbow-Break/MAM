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
        _updater.AddOnClickEventListener(() => ClickButton());
    }

    private void UpdateUI()
    {
        int selectedStudentCount = LunchSceneManager.Controller.SelectedStudentCount;
        var selectedRestaurant = LunchSceneManager.Controller.SelectedRestaurant;
        _updater.SetInteractible(selectedRestaurant != null && selectedStudentCount > 0);
    }

    private void ClickButton()
    {
        ApplyLunch();
        
        // 스텟 결과 변화를 보여줘야 함
        
        GameManager.FlowManager.ToNextScene();// 지울 예정
    }

    private void ApplyLunch()
    {
        var selectedStudents = LunchSceneManager.Controller.SelectedStudents;
        var selectedRestaurant = LunchSceneManager.Controller.SelectedRestaurant;
        foreach (Student student in selectedStudents)
        {
            StudentLevelHelper.ApplyLunch(student, selectedRestaurant);
        }
    }
}
