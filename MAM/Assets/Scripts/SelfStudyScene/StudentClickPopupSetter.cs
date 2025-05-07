using UnityEngine;

public class StudentClickPopupSetter : MonoBehaviour
{
    [SerializeField] private StudentClickPopupUpdater _updater;

    private Student _selectedStudent = null;
    public bool IsPopupOpen => _updater.gameObject.activeInHierarchy;
    public Student SelectedStudent => _selectedStudent;

    private bool _isCutscenePlaying = false;
    public void Initialize()
    {
        _updater.BackGroundButton.onClick.AddListener(ClosePopup);
        _updater.CarrotButton.onClick.AddListener(()=>ComplimentOrScold(EAffinityType.Carrot));
        _updater.WhipButton.onClick.AddListener(()=>ComplimentOrScold(EAffinityType.Whip));
        _updater.HelpButton.onClick.AddListener(HelpStudent);
        
        GameManager.CutsceneManager.ActOnCutSceneEnd += OnEndCutscene;
    }

    public void OpenPopup(string studentId)
    {
        if (_isCutscenePlaying)
            return;
        
        _selectedStudent = GameManager.StudentManager.GetStudent(studentId);
        _updater.InfoUpdater.SetStudent(_selectedStudent);
        _updater.gameObject.SetActive(true);

        //도움버튼 활성화여부
        Team team = GameManager.TeamManager.GetTeam(_selectedStudent);

        if (team == null)
        {
            _updater.HelpButton.gameObject.SetActive(false);
            return;
        }
        
        _updater.HelpButton.gameObject.SetActive(!team.GotHelped);
    }
    
    private void ClosePopup()
    {
        _updater.gameObject.SetActive(false);
    }

    private void ComplimentOrScold(EAffinityType actionType)
    {
        if (_selectedStudent == null)
            return;
        
        StudentLevelHelper.ApplySelfStudyInteraction(_selectedStudent, actionType);
        
        //나중에 컷씬
        if (actionType == EAffinityType.Carrot)
            GameManager.CutsceneManager.PlayCutscene(ECutsceneType.Carrot);
        else if (actionType == EAffinityType.Whip)
            GameManager.CutsceneManager.PlayCutscene(ECutsceneType.Whip);

        _isCutscenePlaying = true;
        
        ClosePopup();
    }

    private void HelpStudent()
    {
        if (_selectedStudent == null)
            return;
        
        Team team = GameManager.TeamManager.GetTeam(_selectedStudent);
        team.GotHelped = true;
        
        GameManager.CutsceneManager.PlayCutscene(ECutsceneType.Help);
        
        ClosePopup();
    }

    private void OnEndCutscene()
    {
        _isCutscenePlaying = false;
        _selectedStudent = null;
        
        SelfStudySceneManager.Instance.UseInteractionCount();
    }
}
