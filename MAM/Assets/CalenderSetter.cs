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
        int index = GetRectIndex(flowMgr.CurrentProject, flowMgr.CurrentDay);
        _updater.SetTeacherPosition(index);
        _updater.SetActive(false);
    }

    private void OnStartNewDay()
    {
        _updater.SetActive(true);
        FlowManager flowMgr = GameManager.FlowManager;
        int index = GetRectIndex(flowMgr.CurrentProject, flowMgr.CurrentDay);
        _updater.MoveTeacher(index);
        _updater.OnMoveFinished += () => _updater.SetActive(false);
    }
    
    public int GetRectIndex(int project, int day)
    {
        return (project - 1) * 4 + (day - 1);
    }
}
