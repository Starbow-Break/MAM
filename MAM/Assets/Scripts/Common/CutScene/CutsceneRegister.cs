using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public class CutsceneRegister : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    [FormerlySerializedAs("_cutsceneName")] [SerializeField] private ECutsceneType cutsceneType;

    protected virtual void Awake()
    {
        GameManager.CutsceneManager.RegisterCutscene(cutsceneType, _director);
    }

    protected virtual void OnDestroy()
    {
        GameManager.CutsceneManager.UnregisterCutscene(cutsceneType);
    }
}
