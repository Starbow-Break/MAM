using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    [SerializeField] private AMiniGame _unityMiniGame = null;
    [SerializeField] private AMiniGame _cSharpMiniGame = null;
    [SerializeField] private MiniGameUIUpdater _uiUpdater = null;
    [SerializeField] private MiniGameCharacterController _characterController = null;

    private AMiniGame _currentMiniGame = null;
    
    public MiniGameUIUpdater UIUpdater => _uiUpdater;
    public MiniGameCharacterController CharacterController => _characterController;

    public void PlayMiniGame(ESkillType miniGameType, int difficulty)
    {
        switch (miniGameType)
        {
            case ESkillType.Unity:
                _currentMiniGame = _unityMiniGame;
                break;
            case ESkillType.CSharp:
                _currentMiniGame = _cSharpMiniGame;  //나중에 교체
                break;
            default:
                _currentMiniGame = _cSharpMiniGame;
                break;
        }
        _currentMiniGame.Initialize(difficulty);
        _uiUpdater.gameObject.SetActive(true);
        _currentMiniGame.StartGame();
    }
}
