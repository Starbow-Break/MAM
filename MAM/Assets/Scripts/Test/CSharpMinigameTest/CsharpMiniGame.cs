using System;
using UnityEngine;

public class CsharpMiniGame: AMiniGame
{
    [SerializeField] private CsharpMiniGameController _controller;
    
    public override void Initialize(int difficulty)
    {
        _difficulty = difficulty;
    }

    public override void StartGame()
    {
        ChartData chartData = ChartDataParser.Parse();
        _controller.Play(chartData);
    }

    public void Start()
    {
        StartGame();
    }
}
