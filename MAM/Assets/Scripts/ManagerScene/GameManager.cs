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
    [SerializeField] private SceneController _sceneManager = null;
    [SerializeField] private StudentManager _studentManager = null;
    [SerializeField] private TeamManager _teamManager = null;

    public static FlowManager FlowManager => Instance._flowManager;
    public static SceneController SceneManager => Instance._sceneManager;
    public static StudentManager StudentManager => Instance._studentManager;
    public static TeamManager TeamManager => Instance._teamManager;

    public bool IsTestMode = false;
    
    private IEnumerator Start()
    {
        yield return new WaitUntil(()=> Application.isPlaying);
        
        if (IsTestMode)
            yield break;
        
        _sceneManager.LoadTitle();
    }

    public void StartGame()
    {
        _sceneManager.LoadScene(ESceneIndex.TeamSelect);
        _studentManager.InitializeStudents();
    }
}
