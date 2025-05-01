using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CalendarSetter : MonoBehaviour
{
    [SerializeField] private CalendarUpdater _updater;

    private void OnEnable()
    {
        GameManager.FlowManager.ActOnNewDayStart += OnStartNewDay;
        GameManager.FlowManager.ActOnNewProjectStart += OnStartNewDay;
    }
    
    private void OnDisable()
    {
        GameManager.FlowManager.ActOnNewDayStart -= OnStartNewDay;
        GameManager.FlowManager.ActOnNewProjectStart -= OnStartNewDay;
    }
    
    private void Start()
    {
        Initialize();
        GameManager.FlowManager.AddCurrentDay();
    }

    private void Initialize()
    {
        FlowManager flowMgr = GameManager.FlowManager;
        _updater.SetTeacherPosition(flowMgr.CurrentProject, flowMgr.CurrentDay);
        _updater.SetActive(false);
    }

    private void OnStartNewDay()
    {
        _updater.SetActive(true);
        FlowManager flowMgr = GameManager.FlowManager;
        _updater.MoveTeacher(flowMgr.CurrentProject, flowMgr.CurrentDay);
        _updater.OnMoveFinished += () => GameManager.FlowManager.ToNextScene();
    }

    private IEnumerator StartNewDayCo()
    {
            yield return null;
        _updater.SetActive(true);
        FlowManager flowMgr = GameManager.FlowManager;
        _updater.MoveTeacher(flowMgr.CurrentProject, flowMgr.CurrentDay);
        _updater.OnMoveFinished += () => _updater.SetActive(false);
    }
    
}
