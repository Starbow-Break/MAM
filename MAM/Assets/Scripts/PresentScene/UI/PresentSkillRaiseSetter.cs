using UnityEngine;

public class PresentSkillRaiseSetter : MonoBehaviour
{
    [SerializeField] private PresentSkillRaiseUpdater _member1Updater = null;
    [SerializeField] private PresentSkillRaiseUpdater _member2Updater = null;

    private PresentSkillRaiseViewer _viewer = null;
    private PresentSkillRaiseViewer _viewer2 = null;
    public void Initialize()
    {
        _member1Updater.gameObject.SetActive(false);
        _member2Updater.gameObject.SetActive(false);

        _viewer = new PresentSkillRaiseViewer(_member1Updater);
        _viewer2 = new PresentSkillRaiseViewer(_member2Updater);
    }

    public void OpenUpdaters(Team team)
    {
        _viewer.StopAllRaiseCo(this);
        _viewer2.StopAllRaiseCo(this);
        
        _viewer.SetSkillLevel(team.ProjectProgress, team.Member1);
        _viewer2.SetSkillLevel(team.ProjectProgress, team.Member2);
        
        _member1Updater.gameObject.SetActive(true);
        _member2Updater.gameObject.SetActive(true);

        _viewer.StartAllRaiseCo(this);
        _viewer2.StartAllRaiseCo(this);
    }

    public void CloseUpdaters()
    {
        _viewer.StopAllRaiseCo(this);
        _viewer2.StopAllRaiseCo(this);
        
        _member1Updater.gameObject.SetActive(false);
        _member2Updater.gameObject.SetActive(false);
    }
}
