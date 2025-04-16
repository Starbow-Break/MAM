using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SubmitButtonUpdater : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetInteractible(bool interactible)
    {
        _button.interactable = interactible;
    }

    public void AddOnClickEventListener(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
}
