using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class UnityWindowCueManager : MonoBehaviour
{
    [SerializeField] private List<UnityWindowCue> _originalCues = null;
    [SerializeField] private Transform _instantiateTransform = null;
    
    public List<UnityWindowCue> _windowCues = null;

    private int _cueCount = 0;
    private int _currentCueIndex = 0;
    private UnityAction _actOnCompleteSet  = null;
    
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

        for (int i = 0; i < _cueCount; i++)
        {
            UnityWindowCue windowCue = Instantiate(GetRandomWindowCue(), _instantiateTransform);
            windowCue.gameObject.SetActive(true);
            _windowCues.Add(windowCue);
        }
    }
    
    //랜덤세트맞추기
    private void SetRandomCues()
    {
        for (int i = 0; i < _cueCount; i++)
        {
            UnityWindowCue randomCue = GetRandomWindowCue();
            _windowCues[i].SetCue(randomCue.WindowType,randomCue.Icon,randomCue.RequiredKey);
            _windowCues[i].SetIncomplete();
        }

        _currentCueIndex = 0;
    }

    public void InputCorrectKey()
    {
        //키 맞으면
        _windowCues[_currentCueIndex].SetComplete();
        _currentCueIndex++;

        if (_currentCueIndex < _windowCues.Count)
            return;
            
        _actOnCompleteSet?.Invoke();
        SetRandomCues();
    }

    public void InputWrongKey()
    {
        _currentCueIndex = 0;
        SetRandomCues();
    }

    public KeyCode GetCurrentKey()
    {
        return _windowCues[_currentCueIndex].RequiredKey;
    }

    public EUnityWindowType GetCurrentWindowType()
    {
        return _windowCues[_currentCueIndex].WindowType;
    }
    
    private UnityWindowCue GetRandomWindowCue()
    {
        int randomIndex = Random.Range(0, _originalCues.Count);
        return _originalCues[randomIndex];
    }
}
