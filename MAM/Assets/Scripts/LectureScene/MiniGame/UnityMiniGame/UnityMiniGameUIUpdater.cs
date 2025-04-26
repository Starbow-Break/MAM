using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnityMiniGameUIUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _score;

    [SerializeField] private Button _skipButton = null;
    
    public Button SkipButton => _skipButton;

    public void SetScore(int score)
    {
        _score.text = score.ToString();
    }

    public void SetTime(float time)
    {
        _time.text = Mathf.CeilToInt(time).ToString();
    }
    
}
