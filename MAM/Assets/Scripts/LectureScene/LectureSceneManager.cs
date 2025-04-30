using System.Collections;
using UnityEngine;

public class LectureSceneManager : ASceneManager<LectureSceneManager>
{
    [SerializeField] private MiniGameController _miniGameController = null;
    [SerializeField] private LectureResultSetter _lectureResultSetter = null;
    public static MiniGameController MiniGameController => Instance._miniGameController;
    
    public void OnEndMiniGame(ESkillType miniGameType, float score, int miniGameDifficulty)
    {
        StartCoroutine(GradePopupCo(miniGameType, score, miniGameDifficulty));
    }

    public void ToNextScene()
    {
        GameManager.FlowManager.ToNextScene();
    }

    public IEnumerator GradePopupCo(ESkillType miniGameType, float score, int miniGameDifficulty)
    {
        yield return MiniGameController.ShowGrade(score);
        _lectureResultSetter.ShowPopup(miniGameType, score, miniGameDifficulty);
    }
}
