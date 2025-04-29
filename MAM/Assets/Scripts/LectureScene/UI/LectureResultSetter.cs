using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LectureResultSetter : MonoBehaviour
{
    [SerializeField] private LectureResultUpdater _updater = null;

    private List<SkillRaiseViewer> _skillRaiseViewers = null;
    private readonly float _activeDelay = 0.2f;
    
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
            
            SkillRaiseViewer newViewer = new SkillRaiseViewer(newUpdater, student.ID); 
            _skillRaiseViewers.Add(newViewer);
        }
        
        _updater.StartButton.onClick.AddListener(ToNextScene);
    }

    public void ShowPopup(ESkillType miniGameType, float score, int miniGameDifficulty)
    {
        _updater.gameObject.SetActive(true);
        
        StartCoroutine(RaiseLevelCo(miniGameType, score, miniGameDifficulty));
    }

    //아이콘채우기
    private IEnumerator RaiseLevelCo(ESkillType miniGameType, float score, int miniGameDifficulty)
    {
        foreach (var viewer in _skillRaiseViewers)
        {
            viewer.SetSkillTypeLevel(miniGameType, score, miniGameDifficulty);
            StartCoroutine(viewer.RaiseCo());
            
            yield return new WaitForSeconds(_activeDelay);
        }
    }

    private void ToNextScene()
    {
        LectureSceneManager.Instance.ToNextScene();
    }
}
