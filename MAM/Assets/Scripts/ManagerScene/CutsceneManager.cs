using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    private Dictionary<ECutsceneType, PlayableDirector> _cutscenes = new Dictionary<ECutsceneType, PlayableDirector>();
    private PlayableDirector _currentCutscene;
    
    public UnityAction ActOnCutSceneStart { get; set; }
    public UnityAction ActOnCutSceneEnd { get; set; }

    public void Initialize()
    {
        GameManager.FlowManager.ActOnSceneSwitch += () =>
        {
            ActOnCutSceneStart = null;
            ActOnCutSceneEnd = null;
        };
    }
    
    public bool IsPlaying()
    {
        if (_currentCutscene == null)
            return false;
        
        return _currentCutscene.state == PlayState.Playing;
    }

    public void RegisterCutscene(ECutsceneType cutsceneType, PlayableDirector cutscene)
    {
        if (_cutscenes.TryAdd(cutsceneType, cutscene) == false)
        {
            Debug.LogWarning("Cutscene already registered");
        }
    }

    public void UnregisterCutscene(ECutsceneType cutsceneType)
    {
        _cutscenes.Remove(cutsceneType);
    }

    public void PlayCutscene(ECutsceneType cutsceneType)
    {
        if (_cutscenes.ContainsKey(cutsceneType))
        {
            Debug.LogWarning(cutsceneType + " is not registered");
            return;
        }
        
        _currentCutscene = _cutscenes[cutsceneType];

        _currentCutscene.stopped += OnCutSceneEnd;
        _currentCutscene.Play();
        ActOnCutSceneStart?.Invoke();
    }

    public void StopCutScene()
    {
        if (_currentCutscene == null)
            return;
        
        _currentCutscene.Stop();
        OnCutSceneEnd(_currentCutscene);
    }

    private void OnCutSceneEnd(PlayableDirector obj)
    {
        ActOnCutSceneEnd?.Invoke();
        obj.stopped -= OnCutSceneEnd;
        _currentCutscene = null;
    }
}
