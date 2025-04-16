using UnityEngine;

public abstract class AMiniGame : MonoBehaviour
{
    protected ESkillType _miniGameType = ESkillType.Unity;
    protected int _difficulty = 0;
    protected int _score = 0; //0~100

    public virtual void Initialize(int difficulty)
    {
        _difficulty = difficulty;
    }
    public abstract void StartGame();

    protected virtual void EndGame()
    {
        LectureSceneManager.Instance.OnEndMiniGame(_miniGameType, _difficulty, _score);
    }
}
