using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class TeamGradeButtonSetter : MonoBehaviour
{
    [SerializeField] private TeamGradeButtonUpdater _originalUpdater = null;
    [SerializeField] private Transform _contentTransform = null;
    [SerializeField] private Button _continueButton = null;
    
    private List<TeamGradeButtonViewer> _viewers = new List<TeamGradeButtonViewer>();
    private RadioButtonGroup _teamGradeButtonGroup = null;

    private float _showButtonDelay = 1f;
    
    public UnityAction<Team> ActOnShowTeamButton { get; set; }
    
    public void Initialize()
    {
        List<Team> teams = GameManager.TeamManager.Teams;
        List<SimpleRadioButton> buttons = new List<SimpleRadioButton>();

        foreach (var team in teams)
        {
            TeamGradeButtonUpdater newUpdater = Instantiate(_originalUpdater, _contentTransform);
            TeamGradeButtonViewer newViewer = new TeamGradeButtonViewer();
            newViewer.Initialize(newUpdater, team);
            
            buttons.Add(newUpdater.RadioButton);
            
            _viewers.Add(newViewer);
        }
        
        _teamGradeButtonGroup = new RadioButtonGroup(buttons.ToArray());
        _teamGradeButtonGroup.OnValueChanged += OnTeamSelected;
        
        //계속버튼
        _continueButton.gameObject.SetActive(false);
        _continueButton.onClick.AddListener(GameManager.FlowManager.ToNextScene);
    }

    public void OnTeamSelected(int teamIndex)
    {
        if (teamIndex == -1)
        {
            PresentSceneManager.SkillRaiseSetter.CloseUpdaters();
            return;
        }
        
        PresentSceneManager.SkillRaiseSetter.OpenUpdaters(_viewers[teamIndex].Team);
    }

    public void ShowButtons()
    {
        StartCoroutine(ShowTeamButtonsCo());
    }

    private IEnumerator ShowTeamButtonsCo()
    {
        foreach (TeamGradeButtonViewer viewer in _viewers)
        {
            viewer.ShowButton();
            ActOnShowTeamButton?.Invoke(viewer.Team);
            yield return new WaitForSeconds(_showButtonDelay);
        }
        
        _continueButton.gameObject.SetActive(true);
    }
}
