using UnityEngine;

public class LectureSceneManager : ASceneManager<LectureSceneManager>
{
    [SerializeField] private MiniGameController _miniGameController = null;
    [SerializeField] private LectureResultSetter _lectureResultSetter = null;
    public MiniGameController MiniGameController => _miniGameController;
    
    public void OnEndMiniGame(ESkillType miniGameType, int score, int miniGameDifficulty)
    {
        _lectureResultSetter.ShowPopup(miniGameType, score, miniGameDifficulty);
    }

    public void ToNextScene()
    {
        GameManager.FlowManager.ToNextScene();
    }
}
