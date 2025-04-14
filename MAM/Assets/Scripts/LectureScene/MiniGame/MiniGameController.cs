using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    [SerializeField] private AMiniGame _unityMiniGame = null;
    [SerializeField] private AMiniGame _cSharpMiniGame = null;

    private AMiniGame _currentMiniGame = null;

    public void PlayMiniGame(EMiniGameType miniGameType, int difficulty)
    {
        switch (miniGameType)
        {
            case EMiniGameType.Unity:
                _currentMiniGame = _unityMiniGame;
                break;
            case EMiniGameType.CSharp:
                _currentMiniGame = _unityMiniGame;  //나중에 교체
                break;
            default:
                _currentMiniGame = _cSharpMiniGame;
                break;
        }
        _currentMiniGame.Initialize(difficulty);
        _currentMiniGame.StartGame();
    }
}
