using UnityEngine;

public abstract class AMiniGame : MonoBehaviour
{
    [SerializeField] protected ESkillType _miniGameType = ESkillType.Unity;

    protected int _difficulty; //1~3
    protected float _score; //0~100

    public float Score
    {
        get => _score;
        set => _score = value;
    }

    public virtual void Initialize(int difficulty)
    {
        _difficulty = difficulty;
        LectureSceneManager.MiniGameController.UIUpdater.SkipButton.onClick.AddListener(EndGame);
    }

    public abstract void StartGame();

    protected virtual void EndGame()
    {
        gameObject.SetActive(false);
        LectureSceneManager.Instance.OnEndMiniGame(_miniGameType, _score, _difficulty);
    }
}