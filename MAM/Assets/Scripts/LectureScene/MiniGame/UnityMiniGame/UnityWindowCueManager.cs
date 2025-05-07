using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class UnityWindowCueManager : MonoBehaviour
{
    [SerializeField] private List<UnityWindowCue> _originalCues;
    [SerializeField] private Transform _instantiateTransform;

    public List<UnityWindowCue> _windowCues;
    private UnityAction _actOnCompleteSet;

    private int _cueCount;
    private int _currentCueIndex;

    public KeyCode GetCurrentRequiredKeyCode => _windowCues[_currentCueIndex].RequiredKey;

    public void InitializeCues(int count, UnityAction actOnCompleteSet)
    {
        _cueCount = count;
        _actOnCompleteSet += actOnCompleteSet;
        GenerateWindowCues();
        SetRandomCues();
    }

    //처음에 생성
    private void GenerateWindowCues()
    {
        _windowCues = new List<UnityWindowCue>();

        for (var i = 0; i < _cueCount; i++)
        {
            var windowCue = Instantiate(GetRandomWindowCue(), _instantiateTransform);
            windowCue.gameObject.SetActive(true);
            _windowCues.Add(windowCue);
        }
    }

    //랜덤세트맞추기
    public void SetRandomCues()
    {
        for (var i = 0; i < _cueCount; i++)
        {
            var randomCue = GetRandomWindowCue();
            _windowCues[i].SetCue(randomCue.WindowType, randomCue.Icon, randomCue.RequiredKey);
            _windowCues[i].SetIncomplete();
        }

        _currentCueIndex = 0;
    }

    public bool TryInputKey(KeyCode inputKey, out EUnityWindowType currentWindowType)
    {
        currentWindowType = _windowCues[_currentCueIndex].WindowType;

        if (inputKey != _windowCues[_currentCueIndex].RequiredKey) return false;

        _windowCues[_currentCueIndex].SetComplete();
        _currentCueIndex++;

        if (_currentCueIndex >= _windowCues.Count) _actOnCompleteSet?.Invoke();

        return true;
    }

    private UnityWindowCue GetRandomWindowCue()
    {
        var randomIndex = Random.Range(0, _originalCues.Count);
        return _originalCues[randomIndex];
    }
}