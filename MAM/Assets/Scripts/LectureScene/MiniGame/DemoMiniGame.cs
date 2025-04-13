using UnityEngine.UI;
using UnityEngine;

public class DemoMiniGame : AMiniGame
{
    [SerializeField]private Button _button = null;
    
    private int _level = 0;
    
    public override void Initialize(int level)
    {
        _level = level;
        _score = 100;
        _button.onClick.AddListener(EndGame);
    }
    
    public override void StartGame()
    {
        gameObject.SetActive(true);
    }
}
