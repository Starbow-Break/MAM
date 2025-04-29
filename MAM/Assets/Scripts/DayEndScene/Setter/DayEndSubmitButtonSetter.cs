using UnityEngine;

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
        GameManager.FlowManager.ToNextScene();
    }
}
