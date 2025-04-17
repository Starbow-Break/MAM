using System.Collections.Generic;
using UnityEngine;

public class LectureResultSetter : MonoBehaviour
{
    [SerializeField] private LectureResultUpdater _updater = null;

    private List<SkillRaiseViewer> _skillRaiseViewers = null;
    
    private void Awake()
    {
        Initialize();
    }

    //로딩때 생성해놓기
    private void Initialize()
    {
        _skillRaiseViewers = new List<SkillRaiseViewer>();
        
        List<Student> students = GameManager.StudentManager.GetStudents();
        foreach (var student in students)
        {
            SkillRaiseUpdater newUpdater = Instantiate(_updater.OriginalUpdater, _updater.ContentTransform);
            newUpdater.gameObject.SetActive(true);
            
            SkillRaiseViewer newViewer = new SkillRaiseViewer(newUpdater, student.ID); 
            _skillRaiseViewers.Add(newViewer);
        }
        
        _updater.StartButton.onClick.AddListener(ToNextScene);
    }

    public void ShowPopup(ESkillType miniGameType)
    {
        _updater.gameObject.SetActive(true);
        
        foreach (var viewer in _skillRaiseViewers)
        {
            viewer.SetSkillTypeLevel(miniGameType);
            viewer.StartRaising();
        }
    }

    public void ToNextScene()
    {
        LectureSceneManager.Instance.ToNextScene();
    }
}
