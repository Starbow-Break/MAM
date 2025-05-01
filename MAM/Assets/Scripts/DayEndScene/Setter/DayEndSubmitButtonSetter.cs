using UnityEngine;
using UnityEngine.Serialization;

public class DayEndSubmitButtonSetter : MonoBehaviour
{
    [SerializeField] private SubmitButtonUpdater _updater;
    [FormerlySerializedAs("_calender")] [SerializeField] private CalendarUpdater calendar;

    public void Initialize()
    {
        _updater.SetInteractible(true);
        _updater.AddOnClickEventListener(() => OnClick());
    }

    private void OnClick()
    {
        GameManager.FlowManager.ToNextScene();
    }
}
