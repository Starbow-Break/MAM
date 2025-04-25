using System;
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
    
    public static CSharpMiniGame Instance { get; private set; }
    
    public static CSharpMiniGameController Controller => Instance._controller;
    public static CSharpMiniGameInput Input => Instance._input;
    public static VisualizeCountSetter VisualizeCountSetter => Instance._visualizeCountSetter;
    
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
    
    public override void Initialize(int difficulty)
    {
        _difficulty = difficulty;
    }

    public override void StartGame()
    {
        InitializeUI();
        ChartData chartData = ChartDataParser.Parse();
        _controller.Play(chartData);
    }

    public void InitializeUI()
    {
        _visualizeCountSetter.Initialize();
        _hitEffectSetter.Initialize();
        _judgeEffectSetter.Initialize();
    }

    private void Start()
    {
        StartGame();
    }
}
