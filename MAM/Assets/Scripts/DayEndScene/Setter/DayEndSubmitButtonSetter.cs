using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayEndSubmitButtonSetter : MonoBehaviour
{
    [SerializeField] private SubmitButtonUpdater _updater;
    [SerializeField] private CalenderUpdater _calender;

    public void Initialize()
    {
        _updater.SetInteractible(true);
        _updater.AddOnClickEventListener(() => OnClick());
    }

    private void OnClick()
    {
        _calender.gameObject.SetActive(true);
        _calender.MoveNext();
        _calender.OnMoveFinished += () => GameManager.FlowManager.ToNextScene();
    }
}
