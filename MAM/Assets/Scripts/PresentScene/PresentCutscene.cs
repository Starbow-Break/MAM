using UnityEngine;
using UnityEngine.Playables;

public class PresentCutscene : MonoBehaviour
{
    [SerializeField] private CutsceneActor _presenter = null;
    [SerializeField] private PlayableDirector _director = null;

    private void Start()
    {
        _director.stopped += OnTimelineStopped;
        PresentSceneManager.ButtonSetter.ActOnShowTeamButton += ChangeActor;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        director.time = 0;
        director.Play();
    }

    private void ChangeActor(Team team)
    {
        if (team.Member1 == null)
            return;
        _presenter.SetActor(team.Member1.ID);
    }
}