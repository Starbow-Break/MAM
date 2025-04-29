using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
public class ContestSceneManager : ASceneManager<ContestSceneManager>
{
    [SerializeField] private TeamGradeButtonSetter _teamGradeButtonSetter = null;
    [SerializeField] private ContestTeamSetter _contestTeamSetter = null;
    [SerializeField] private PresentSceneCharacterSetter _presentSceneCharacterSetter = null;
    
    [SerializeField] private DemoGameManagerHelper _demoGameManagerHelperOrNull = null;

    public static List<ContestTeam> Teams => Instance._contestTeamSetter.GetTeams;
    
    private void Start()
    {
        Initialize();
        
        //_teamGradeButtonSetter.ShowButtons();
    }

    private void Initialize()
    {
        if(GameManager.Instance.IsTestMode)
            _demoGameManagerHelperOrNull.SetDemoTeam();   //임시로팀만들기
        
        _contestTeamSetter.Initialize();
        
        //_teamGradeButtonSetter.Initialize();
        //_presentSceneCharacterSetter.Initialize();
    }

}
