using UnityEngine;
using UnityEngine.UI;

public class DemoMiniGame : AMiniGame
{
    [SerializeField] private Button _button;

    public override void Initialize(int difficulty)
    {
        _difficulty = difficulty;
        _score = 100;
        _button.onClick.AddListener(EndGame);
    }

    public override void StartGame()
    {
        gameObject.SetActive(true);
    }
}