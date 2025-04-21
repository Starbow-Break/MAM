using UnityEngine;

public class LunchRaiseIntimacySubmitButtonSetter : MonoBehaviour
{
    [SerializeField] private SubmitButtonUpdater _updater;

    public void Initialize()
    {
        _updater.AddOnClickEventListener(() => OnClick());
    }

    private void OnClick()
    {
        GameManager.FlowManager.ToNextScene();
    }
}
