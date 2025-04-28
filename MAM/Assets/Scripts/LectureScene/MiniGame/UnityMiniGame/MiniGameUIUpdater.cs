using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameUIUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _time = null;
    [SerializeField] private TextMeshProUGUI _score = null;
    [SerializeField] private GameObject _timePanel = null;

    [SerializeField] private Button _skipButton = null;
    
    public Button SkipButton => _skipButton;

    private void Start()
    {
        gameObject.SetActive(false);
        _timePanel.SetActive(false);
    }
    
    public void SetScore(int score)
    {
        _score.text = score.ToString();
    }

    public void SetTime(float time)
    {
        _time.text = Mathf.CeilToInt(time).ToString();
    }

    public void ShowTime()
    {
        _timePanel.SetActive(true);
    }
}
