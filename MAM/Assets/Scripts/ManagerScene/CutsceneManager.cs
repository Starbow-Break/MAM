using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    private Dictionary<ECutsceneName, PlayableDirector> _cutscenes = new Dictionary<ECutsceneName, PlayableDirector>();
    private PlayableDirector _currentCutscene;
    
    public UnityAction ActOnCutSceneStart { get; set; }
    public UnityAction ActOnCutSceneEnd { get; set; }

    public bool IsPlaying()
    {
        if (_currentCutscene == null)
            return false;
        
        return _currentCutscene.state == PlayState.Playing;
    }

    public void RegisterCutscene(ECutsceneName cutsceneName, PlayableDirector cutscene)
    {
        if (_cutscenes.TryAdd(cutsceneName, cutscene) == false)
        {
            Debug.LogWarning("Cutscene already registered");
        }
    }

    public void UnregisterCutscene(ECutsceneName cutsceneName)
    {
        _cutscenes.Remove(cutsceneName);
    }

    public void PlayCutscene(ECutsceneName cutsceneName)
    {
        _currentCutscene = _cutscenes[cutsceneName];
        
        if (_currentCutscene == null)
        {
            Debug.LogWarning(cutsceneName + " is not registered");
            return;
        }

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
