using UnityEngine;
using System.Collections;

[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    [SerializeField] private FlowManager _flowManager = null;
    [SerializeField] private StudentManager _studentManager = null;
    [SerializeField] private TeamManager _teamManager = null;
    [SerializeField] private RestaurantTable _restaurantTable = null;
    
    public static FlowManager FlowManager => Instance._flowManager;
    public static StudentManager StudentManager => Instance._studentManager;
    public static TeamManager TeamManager => Instance._teamManager;
    public static RestaurantTable RestaurantTable => Instance._restaurantTable;

    public bool IsTestMode = false;
    
    private IEnumerator Start()
    {
        yield return new WaitUntil(()=> Application.isPlaying);
        
        if (IsTestMode)
            yield break;
        
        _flowManager.LoadTitle();
    }

    public void StartGame()
    {
        _flowManager.GameStart();
        _studentManager.InitializeStudents();
    }
}
