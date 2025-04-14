using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController = null;
    [SerializeField] private Button _demoNextSceneButton = null;
    
    [SerializeField] private int _totalDayInProject = 3;
    //[SerializeField] private int _totalProjectCount = 3;
    private int _currentDay = 0;
    private int _currentProject = 0;

    public UnityAction ActOnSceneSwitch{ get; set; }    //씬언로드전 마지막행동
    
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
        _currentProject++;
        _currentDay++;
    }
    
    public void ToNextScene()
    {
        ActOnSceneSwitch?.Invoke();
        ActOnSceneSwitch = null;
        
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
                if (_currentDay >= _totalDayInProject)
                {
                    _sceneController.LoadScene(ESceneIndex.Present);
                    break;
                }
                _currentDay++;
                _sceneController.LoadScene(ESceneIndex.Lecture);
                break;
            
            case ESceneIndex.Present:
                _currentProject++;
                _sceneController.LoadScene(ESceneIndex.TeamSelect);
                break;
        }
    }
}
