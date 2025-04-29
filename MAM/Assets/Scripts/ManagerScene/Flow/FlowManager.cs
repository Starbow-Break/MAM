using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController = null;
    [SerializeField] private Button _demoNextSceneButton = null;
    
    [SerializeField] private FlowData _flowData = null;
    
    private int _currentDay = 1;
    private int _currentProject = 1;
    
    public int CurrentDay {get {return _currentDay;}}
    public int CurrentProject {get {return _currentProject;}}
    public UnityAction ActOnSceneSwitch{ get; set; }    //씬언로드전 마지막행동
    public UnityAction ActOnNewDayStart { get; set; }   //새 하루 시작할때
    public UnityAction ActOnNewProjectStart{ get; set; }    //새프로잭트시작할때 팀선정 전
    
    private void Start()
    {
        if (_demoNextSceneButton == null)
            return;
        _demoNextSceneButton.onClick.AddListener(ToNextScene);
    }

    public void LoadTitle() => _sceneController.LoadTitle();
    
    //첫시작
    public void GameStart()
    {
        //필요하다면 나중에 날, 프로젝트 카운트 세팅
        _sceneController.LoadScene(ESceneIndex.TeamSelect);
        _currentProject = 1;
        _currentDay = 1;
    }
    
    public void ToNextScene()
    {
        ActOnSceneSwitch?.Invoke();
        
        switch (_sceneController.CurrentScene)
        {
            case ESceneIndex.TeamSelect:
                _sceneController.LoadScene(ESceneIndex.Lecture);
                break;
            case ESceneIndex.Lecture:
                _sceneController.LoadScene(ESceneIndex.Lunch);
                break;
            case ESceneIndex.Lunch:
                _sceneController.LoadScene(ESceneIndex.SelfStudy);
                break;
            case ESceneIndex.SelfStudy:
                _sceneController.LoadScene(ESceneIndex.DayEnd);
                break;
            
            case ESceneIndex.DayEnd:
                if (_currentDay >= _flowData.TotalDaysInProject)
                {
                    _sceneController.LoadScene(ESceneIndex.Present);
                    break;
                }
                _currentDay++;
                ActOnNewDayStart?.Invoke();
                _sceneController.LoadScene(ESceneIndex.Lecture);
                break;
            
            case ESceneIndex.Present:
                _currentProject++;
                _currentDay = 1;
                ActOnNewProjectStart?.Invoke();
                _sceneController.LoadScene(ESceneIndex.TeamSelect);
                break;
        }
    }

    public float GetCurrentProjectGoal()
    {
        int index = Mathf.Clamp(_currentProject - 1, 0, _flowData.TotalProjectCount - 1);
        return _flowData.ProjectProgressGoals[index];
    }

}
