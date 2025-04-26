using System;
using UnityEngine;
using UnityEngine.Events;

public class UnityWindowInputHandler : MonoBehaviour
{
    private UnityWindowCueManager _cueManager = null;
    private Action<EUnityWindowType> _onCorrectInput = null;
    private Action _onWrongInput = null;

    public bool IsOnDelay { get; set; } = true;

    public void Initialize(UnityWindowCueManager cueManager, Action<EUnityWindowType> onCorrectInput,
        Action onWrongInput)
    {
        _cueManager = cueManager;
        _onCorrectInput = onCorrectInput;
        _onWrongInput = onWrongInput;
    }
    
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

            if (_cueManager.TryInputKey(keyCode, out EUnityWindowType windowType))
            {
                _onCorrectInput?.Invoke(windowType);
            }
            else
            {
                _onWrongInput?.Invoke();
            }

            break;
        }
    }
}
