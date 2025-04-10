using UnityEngine;

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
    [SerializeField] private SceneManager _sceneManager = null;
    [SerializeField] private StudentManager _studentManager = null;
    [SerializeField] private TeamManager _teamManager = null;

    public static FlowManager FlowManager => Instance._flowManager;
    public static SceneManager SceneManager => Instance._sceneManager;
    public static StudentManager StudentManager => Instance._studentManager;
    public static TeamManager TeamManager => Instance._teamManager;
}
