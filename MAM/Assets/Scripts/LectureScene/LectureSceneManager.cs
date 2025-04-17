using UnityEngine;

public class LectureSceneManager : ASceneManager<LectureSceneManager>
{
    [SerializeField] private MiniGameController _miniGameController = null;
    [SerializeField] private LectureResultSetter _lectureResultSetter = null;
    public MiniGameController MiniGameController => _miniGameController;
    
    public void OnEndMiniGame(ESkillType miniGameType, int miniGameDifficulty, int score)
    {
        _lectureResultSetter.ShowPopup(miniGameType);
        
        if (miniGameType == ESkillType.Unity)
        {
            GameManager.StudentManager.ApplyMiniGameScore(score, miniGameDifficulty, miniGameType);
        }
    }

    public void ToNextScene()
    {
        GameManager.FlowManager.ToNextScene();
    }
}
