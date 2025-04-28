using UnityEngine;
using UnityEngine.Playables;

public class CutsceneRegister : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private ECutsceneName _cutsceneName;

    protected virtual void Start()
    {
        GameManager.CutsceneManager.RegisterCutscene(_cutsceneName, _director);
    }

    protected virtual void OnDestroy()
    {
        GameManager.CutsceneManager.UnregisterCutscene(_cutsceneName);
    }
}
