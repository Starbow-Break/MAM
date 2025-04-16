using UnityEngine;

public class LectureSceneManager : ASceneManager<LectureSceneManager>
{
    [SerializeField] private MiniGameController _miniGameController;
    
    public MiniGameController MiniGameController => _miniGameController;
    
    public void OnEndMiniGame(ESkillType miniGameType, int miniGameDifficulty, int score)
    {
        if (miniGameType == ESkillType.Unity)
        {
            GameManager.StudentManager.ApplyMiniGameScore(score, miniGameDifficulty, miniGameType);
        }
        
        //나중에 UI연출
        
        GameManager.FlowManager.ToNextScene();
    }
}
