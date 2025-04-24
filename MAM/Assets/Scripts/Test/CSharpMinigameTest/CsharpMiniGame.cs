using System;
using UnityEngine;

public class CsharpMiniGame: AMiniGame
{
    [SerializeField] private CsharpMiniGameController _controller;
    [SerializeField] private VisualizeCountSetter _visualizeCountSetter;
    
    public static CsharpMiniGame Instance { get; private set; }
    
    public VisualizeCountSetter VisualizeCountSetter => _visualizeCountSetter;
    
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
        _visualizeCountSetter.SetCount(0);
    }

    private void Start()
    {
        StartGame();
    }
}
