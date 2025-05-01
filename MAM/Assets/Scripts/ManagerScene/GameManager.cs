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
    [SerializeField] private CommonHUDManager _commonHUDManager = null;
    [SerializeField] private CutsceneManager _cutsceneManager = null;
    [SerializeField] private AudioManager _audioManager = null;
    
    public static FlowManager FlowManager => Instance._flowManager;
    public static StudentManager StudentManager => Instance._studentManager;
    public static TeamManager TeamManager => Instance._teamManager;
    public static RestaurantTable RestaurantTable => Instance._restaurantTable;
    public static CommonHUDManager HUDManager => Instance._commonHUDManager;
    public static CutsceneManager CutsceneManager => Instance._cutsceneManager;
    public static AudioManager AudioManager => Instance._audioManager;

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
        _studentManager.InitializeStudents();
        _teamManager.Initialize();
        _commonHUDManager.Initialize();
        _cutsceneManager.Initialize();
        _flowManager.GameStart();
        
        _audioManager.PlayBGM();
    }
}
