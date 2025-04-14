using UnityEngine;

public enum EMiniGameType
{
    Unity = 0,
    CSharp = 1
}

public class LectureSceneManager : ASceneManager<LectureSceneManager>
{
    [SerializeField] private MiniGameController _miniGameController;
    
    public MiniGameController MiniGameController => _miniGameController;
    
    public void OnEndMiniGame(EMiniGameType miniGameType, int miniGameDifficulty, int score)
    {
        if (miniGameType == EMiniGameType.Unity)
        {
            GameManager.StudentManager.ApplyMiniGameResultUnity(score, miniGameDifficulty);
        }
        
        //나중에 UI연출
        
        GameManager.FlowManager.ToNextScene();
    }
}
