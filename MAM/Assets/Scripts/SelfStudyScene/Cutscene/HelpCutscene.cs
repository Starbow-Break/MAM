using UnityEngine;

public class HelpCutscene : MonoBehaviour
{
    [SerializeField] private CutsceneActor _student1 = null;
    [SerializeField] private CutsceneActor _student2 = null;

    private void OnEnable()
    {
        Student student = SelfStudySceneManager.StudentClickPopupSetter.SelectedStudent;
        
        if (student == null)
            return;

        Team team = GameManager.TeamManager.GetTeam(student);

        if (team == null)
            return;
        
        _student1.SetActor(team.Member1.ID);
        _student2.SetActor(team.Member2.ID);
    }
}
