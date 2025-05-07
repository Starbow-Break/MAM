using System.Collections;
using UnityEngine;

public class UnityMiniGame : AMiniGame
{
    private static readonly float _gameTime = 60; //초
    private static readonly float _delayBetweenSets = 0.3f;
    private static readonly int _baseCueCount = 3;
    private static readonly int _baseScore = 7;
    [SerializeField] private UnityWindowCueManager _unityWindowCueManager;
    [SerializeField] private UnityScreenController _screenController;
    [SerializeField] private UnityWindowInputHandler _inputHandler;
    [SerializeField] private UnityMiniGameAudioController _audio;
    private MiniGameCharacterController _characterCon;

    private int _correctSetCount;
    private MiniGameUIUpdater _uiUpdater;

    public override void Initialize(int difficulty)
    {
        base.Initialize(difficulty);

        _unityWindowCueManager.InitializeCues(_baseCueCount + difficulty, OnCompleteSet);
        _inputHandler.Initialize(_unityWindowCueManager, OnCorrectInput, OnWrongInput);

        _characterCon = LectureSceneManager.MiniGameController.CharacterController;
        _uiUpdater = LectureSceneManager.MiniGameController.UIUpdater;
    }

    public override void StartGame()
    {
        gameObject.SetActive(true);
        _screenController.gameObject.SetActive(true);
        _characterCon.SetInstructorTalking(true);
        _inputHandler.IsOnDelay = false;
        _uiUpdater.ShowTime();
        _audio.PlayBGM();

        StartCoroutine(ProcessGame());
    }

    private IEnumerator ProcessGame()
    {
        var currentTime = _gameTime;

        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            _uiUpdater.SetTime(currentTime);
            yield return null;
        }

        EndGame();
    }

    private void OnCompleteSet()
    {
        _characterCon.PlayInstructorEmote(EEmoteType.BlueExclamation, _delayBetweenSets);
        _characterCon.PlayStudentsEmote(EEmoteType.BlueExclamation, _delayBetweenSets);

        _screenController.ShowCorrectImage();
        _correctSetCount++;
        _uiUpdater.SetScore(_correctSetCount);

        _audio.PlayCorrectSetSound();

        StartCoroutine(DelaySetAndSetCues());
    }

    private void OnCorrectInput(EUnityWindowType type)
    {
        _screenController.HighLightWindow(type);
        _audio.PlayButtonPressSound();
    }

    private void OnWrongInput()
    {
        _characterCon.PlayInstructorEmote(EEmoteType.RedExclamation, _delayBetweenSets);
        _characterCon.PlayStudentsEmote(EEmoteType.RedExclamation, _delayBetweenSets);
        _screenController.ShowIncorrectImage();

        _audio.PlayWrongSetSound();

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

    protected override void EndGame()
    {
        StopAllCoroutines();
        _audio.StopBGM();
        _characterCon.SetInstructorTalking(false);
        _score = Mathf.Clamp(_correctSetCount * _baseScore, 0, 100);
        base.EndGame();
    }
}