using UnityEngine;

public class TeamSelectSubmitButtonSetter : MonoBehaviour
{
    [SerializeField] TeamSelectSceneController _controller;
    [SerializeField] TeamSelectSubmitButtonUpdater _updater;

    private int _totalStudents;

    private void Awake()
    {
        _totalStudents = GameManager.StudentManager.GetStudents().Count;
    }
    private void OnEnable()
    {
        _controller.OnChangeStudent += () => UpdateButtonInteractable();
    }

    private void OnDisable()
    {
        _controller.OnChangeStudent -= () => UpdateButtonInteractable();
    }
    
    public void Initialize()
    {
        _updater.SetInteractible(false);
        _updater.AddOnClickEventListener(() =>
        {
            var teamList = _controller.GetTeamList();
            GameManager.TeamManager.SetTeams(teamList);
            GameManager.FlowManager.ToNextScene();
        });
    }
    
    private void UpdateButtonInteractable()
    {
        bool allRegistered = _controller.RegisteredStudents == _totalStudents;
        _updater.SetInteractible(allRegistered);
    }
}
