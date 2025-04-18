using UnityEngine.UI;
using UnityEngine;

public class DemoMiniGame : AMiniGame
{
    [SerializeField] private Button _button = null;
    
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
