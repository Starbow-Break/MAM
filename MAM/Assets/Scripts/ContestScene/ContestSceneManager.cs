using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
public class ContestSceneManager : ASceneManager<ContestSceneManager>
{
    [SerializeField] private TeamRankButtonSetter _teamRankButtonSetter = null;
    [SerializeField] private ContestTeamSetter _contestTeamSetter = null;
    [SerializeField] private ContestSceneCharacterSetter _characterSetter = null;
    
    [SerializeField] private DemoGameManagerHelper _demoGameManagerHelperOrNull = null;

    private UnityAction<ContestTeam> _actOnTeamSelected = null;

    public static List<ContestTeam> Teams => Instance._contestTeamSetter.GetTeams;
    public static UnityAction<ContestTeam> ActOnTeamSelected => Instance._actOnTeamSelected;
    
    private void Start()
    {
        Initialize();
        
        _teamRankButtonSetter.ShowButtons();
    }

    private void Initialize()
    {
        if(GameManager.Instance.IsTestMode)
            _demoGameManagerHelperOrNull.SetDemoTeam();   //임시로팀만들기
        
        _contestTeamSetter.Initialize();
        _characterSetter.Initialize();
        _teamRankButtonSetter.Initialize();
    }
}
