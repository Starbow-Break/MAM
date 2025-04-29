using Unity.VisualScripting;
using UnityEngine;

public class CalenderSetter : MonoBehaviour
{
    [SerializeField] private CalenderUpdater _updater;

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
        _updater.OnMoveFinished += () => _updater.SetActive(false);
    }
    
    
}
