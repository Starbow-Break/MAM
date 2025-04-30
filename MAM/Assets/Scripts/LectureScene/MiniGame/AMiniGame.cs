using UnityEngine;
using UnityEngine.UI;

public abstract class AMiniGame : MonoBehaviour
{
    [SerializeField] protected ESkillType _miniGameType = ESkillType.Unity;
    [SerializeField] protected Button _skipButton;
    
    protected int _difficulty = 0; //1~3
    protected float _score = 0; //0~100

    public float Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public virtual void Initialize(int difficulty)
    {
        _difficulty = difficulty;
        _skipButton.onClick.AddListener(EndGame);
    }
    public abstract void StartGame();

    protected virtual void EndGame()
    {
        gameObject.SetActive(false);
        LectureSceneManager.Instance.OnEndMiniGame(_miniGameType, _score, _difficulty);
    }
}

