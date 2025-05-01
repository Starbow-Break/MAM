using System.ComponentModel.Design.Serialization;
using UnityEngine;
public class PresentSceneManager : ASceneManager<PresentSceneManager>
{
    [SerializeField] private TeamGradeButtonSetter _teamGradeButtonSetter = null;
    [SerializeField] private PresentSkillRaiseSetter _presentSkillRaiseSetter = null;
    [SerializeField] private PresentSceneCharacterSetter _presentSceneCharacterSetter = null;
    
    [SerializeField] private DemoGameManagerHelper _demoGameManagerHelper = null;

    public static PresentSkillRaiseSetter SkillRaiseSetter => Instance._presentSkillRaiseSetter;
    public static TeamGradeButtonSetter ButtonSetter => Instance._teamGradeButtonSetter;
    
    private void Start()
    {
        Initialize();
        
        _teamGradeButtonSetter.ShowButtons();
        
        GameManager.CutsceneManager.PlayCutscene(ECutsceneName.Present);
    }

    private void Initialize()
    {
        if(GameManager.Instance.IsTestMode)
            _demoGameManagerHelper.SetDemoTeam();   //임시로팀만들기
        
        _teamGradeButtonSetter.Initialize();
        _presentSkillRaiseSetter.Initialize();
        _presentSceneCharacterSetter.Initialize();
    }

}
