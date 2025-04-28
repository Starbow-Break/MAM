using System.Collections;
using UnityEngine;

public class UnityMiniGame : AMiniGame
{
    [SerializeField] private UnityWindowCueManager _unityWindowCueManager = null;
    [SerializeField] private UnityScreenController _screenController = null;
    [SerializeField] private UnityWindowInputHandler _inputHandler = null;

    private int _correctSetCount = 0;
    private MiniGameCharacterController _characterCon = null;
    private MiniGameUIUpdater _uiUpdater = null;

    private static readonly float _gameTime = 60; //초
    private static readonly float _delayBetweenSets = 0.3f;
    private static readonly int _baseCueCount = 3;
    private static readonly int _baseScore = 7;

    public override void Initialize(int difficulty)
    {
        _difficulty = difficulty;
        _unityWindowCueManager.InitializeCues(_baseCueCount + difficulty, OnCompleteSet);
        _inputHandler.Initialize(_unityWindowCueManager, OnCorrectInput, OnWrongInput);
        LectureSceneManager.MiniGameController.UIUpdater.SkipButton.onClick.AddListener(OnEndGame);
        
        _characterCon = LectureSceneManager.MiniGameController.CharacterController;
        _uiUpdater = LectureSceneManager.MiniGameController.UIUpdater;
    }

    public override void StartGame()
    {
        gameObject.SetActive(true);
        _characterCon.SetInstructorTalking(true);
        _inputHandler.IsOnDelay = false;
        _uiUpdater.ShowTime();
        StartCoroutine(ProcessGame());
    }

    private IEnumerator ProcessGame()
    {

        float currentTime = _gameTime;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            _uiUpdater.SetTime(currentTime);
            yield return null;
        }

        OnEndGame();
    }

    private void OnCompleteSet()
    {
        _characterCon.PlayInstructorEmote(EEmoteType.BlueExclamation, _delayBetweenSets);
        _screenController.ShowCorrectImage();
        _correctSetCount++;
        _uiUpdater.SetScore(_correctSetCount);
        
        StartCoroutine(DelaySetAndSetCues());
    }

    private void OnCorrectInput(EUnityWindowType type)
    {
        _screenController.HighLightWindow(type);
    }

    private void OnWrongInput()
    {
        _characterCon.PlayInstructorEmote(EEmoteType.RedExclamation, _delayBetweenSets);
        _characterCon.PlayStudentsEmote(EEmoteType.RedExclamation, _delayBetweenSets);
        _screenController.ShowIncorrectImage();
        
        StartCoroutine(DelaySetAndSetCues());
    }

    private IEnumerator DelaySetAndSetCues()
    {
        _inputHandler.IsOnDelay = true;
        yield return new WaitForSeconds(_delayBetweenSets);
        _inputHandler.IsOnDelay = false;
        
        _unityWindowCueManager.SetRandomCues();
        _screenController.ShowIdleImage();
    }

    private void OnEndGame()
    {
        StopAllCoroutines();
        _score = Mathf.Clamp(_correctSetCount * _baseScore, 0, 100);
        EndGame();
    }

}
