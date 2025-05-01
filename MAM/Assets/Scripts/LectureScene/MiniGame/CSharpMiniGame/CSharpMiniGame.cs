using UnityEngine;

[DefaultExecutionOrder(-900)]
public class CSharpMiniGame: AMiniGame
{
    [SerializeField] private CSharpMiniGameController _controller;
    [SerializeField] private CSharpMiniGameInput _input;
    
    [Header("Setters")]
    [SerializeField] private VisualizeCountSetter _visualizeCountSetter;
    [SerializeField] private CSharpMiniGameHitEffectSetter _hitEffectSetter;
    [SerializeField] private CSharpMiniGameJudgeEffectSetter _judgeEffectSetter;
    [SerializeField] private SpeechBubbleSetter _speechBubbleSetter;
    [SerializeField] private CSharpJudgeLineSetter _judgeLineSetter;
    
    [Header("Data")]
    [SerializeField] private MusicDataTable _musicDataTable;
    
    public static CSharpMiniGame Instance { get; private set; }
    
    public static CSharpMiniGameController Controller => Instance._controller;
    public static CSharpMiniGameInput Input => Instance._input;
    public static VisualizeCountSetter VisualizeCountSetter => Instance._visualizeCountSetter;
    public static SpeechBubbleSetter SpeechBubbleSetter => Instance._speechBubbleSetter;
    public static CSharpJudgeLineSetter JudgeLineSetter => Instance._judgeLineSetter;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnEnable()
    {
        Controller.OnPlayChartEnded += () => EndGame();
    }

    private void OnDisable()
    {
        Controller.OnPlayChartEnded -= () => EndGame();
    }

    private ChartData GetChartDataFromTable(int difficulty)
    {
        MusicData musicData = _musicDataTable.GetMusicDataRandomly();
        ChartData chartData = ChartDataParser.Parse(musicData.GetChartPath(difficulty));
        chartData.MusicClip = musicData.musicClip;
        return chartData;
    }

    public override void StartGame()
    {
        gameObject.SetActive(true);
        InitializeUI();
        ChartData chartData = GetChartDataFromTable(_difficulty);
        _controller.Play(chartData);
    }

    public void InitializeUI()
    {
        _visualizeCountSetter.Initialize();
        _hitEffectSetter.Initialize();
        _judgeEffectSetter.Initialize();
        _speechBubbleSetter.Initialize();
        _judgeLineSetter.Initialize();
    }
}
