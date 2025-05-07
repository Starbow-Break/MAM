using System;
using UnityEngine;

public class UnityWindowInputHandler : MonoBehaviour
{
    private UnityWindowCueManager _cueManager;
    private Action<EUnityWindowType> _onCorrectInput;
    private Action _onWrongInput;

    public bool IsOnDelay { get; set; } = true;

    private void Update()
    {
        if (IsOnDelay)
            return;

        if (!Input.anyKeyDown)
            return;

        if (Input.GetMouseButtonDown(0))
            return;

        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            if (!Input.GetKeyDown(keyCode))
                continue;

            if (_cueManager.TryInputKey(keyCode, out var windowType))
                _onCorrectInput?.Invoke(windowType);
            else
                _onWrongInput?.Invoke();

            break;
        }
    }

    public void Initialize(UnityWindowCueManager cueManager, Action<EUnityWindowType> onCorrectInput,
        Action onWrongInput)
    {
        _cueManager = cueManager;
        _onCorrectInput = onCorrectInput;
        _onWrongInput = onWrongInput;
    }
}