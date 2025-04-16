using UnityEngine;

public class TeamSelectSubmitButtonSetter : MonoBehaviour
{
    [SerializeField] SubmitButtonUpdater _updater;

    private int _totalStudents;

    private void Awake()
    {
        _totalStudents = GameManager.StudentManager.GetStudents().Count;
    }
    private void OnEnable()
    {
        var controller = TeamSelectSceneManager.Controller;
        controller.OnChangeStudent += () => UpdateButtonInteractable();
    }

    private void OnDisable()
    {
        var controller = TeamSelectSceneManager.Controller;
        controller.OnChangeStudent -= () => UpdateButtonInteractable();
    }
    
    public void Initialize()
    {
        _updater.SetInteractible(false);
        _updater.AddOnClickEventListener(() =>
        {
            var teamList = TeamSelectSceneManager.Controller.GetTeamList();
            GameManager.TeamManager.SetTeams(teamList);
            GameManager.FlowManager.ToNextScene();
        });
    }
    
    private void UpdateButtonInteractable()
    {
        bool allRegistered = TeamSelectSceneManager.Controller.RegisteredStudents == _totalStudents;
        _updater.SetInteractible(allRegistered);
    }
}
