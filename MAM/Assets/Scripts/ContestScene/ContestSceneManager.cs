using System.ComponentModel.Design.Serialization;
using UnityEngine;
public class ContestSceneManager : ASceneManager<ContestSceneManager>
{
    [SerializeField] private TeamGradeButtonSetter _teamGradeButtonSetter = null;
    [SerializeField] private PresentSceneCharacterSetter _presentSceneCharacterSetter = null;
    
    [SerializeField] private DemoGameManagerHelper _demoGameManagerHelper = null;

    
    private void Start()
    {
        Initialize();
        
        _teamGradeButtonSetter.ShowButtons();
    }

    private void Initialize()
    {
        if(GameManager.Instance.IsTestMode)
            _demoGameManagerHelper.SetDemoTeam();   //임시로팀만들기
        
        _teamGradeButtonSetter.Initialize();
        _presentSceneCharacterSetter.Initialize();
    }

}
