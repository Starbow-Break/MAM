using System.Collections;
using UnityEngine;

public class UnityMiniGame : AMiniGame
{
    [SerializeField] private UnityWindowCueManager _unityWindowCueManager = null;
    [SerializeField] private MiniGameCharacterController _characterController = null;
    [SerializeField] private UnityScreenController _screenController = null;
    
    private int _correctSetCount = 0;
    private static readonly float _gameTime = 5000f; //초
    private static readonly float _delayBetweenSets = 0.2f;
    
    public override void Initialize(int difficulty)
    {
        _difficulty = difficulty;
        _unityWindowCueManager.InitializeCues(7,AddCorrectCount);
    }
    public override void StartGame()
    {
        _characterController.SetInstructorTalking(true);

        StartCoroutine(ProcessGame());
    }

    private IEnumerator ProcessGame()
    {
        
        float currentTime = 0;
        KeyCode inputKey = _unityWindowCueManager.GetCurrentKey();

        while (currentTime < _gameTime)
        {
            currentTime += Time.deltaTime;

            if (!Input.anyKeyDown)
            {
                yield return null;
                continue;
            }

            if (Input.GetMouseButtonDown(0))
            {
                yield return null;
                continue;
            }

            if (Input.GetKeyDown(inputKey)) 
            {
                //맞은키
                _screenController.HighLightWindow(_unityWindowCueManager.GetCurrentWindowType());
                _unityWindowCueManager.InputCorrectKey();
            }
            else
            {
                //틀린키
                InputWrongKey();
                yield return new WaitForSeconds(_delayBetweenSets);
                _unityWindowCueManager.InputWrongKey();
                _screenController.ShowIdleImage();
            }
            
            inputKey = _unityWindowCueManager.GetCurrentKey();
            yield return null;
        }

        _score = _correctSetCount * 10;
        EndGame();
    }

    private void AddCorrectCount()
    {
        _characterController.PlayInstructorEmote(EEmoteType.BlueExclamation);
        _screenController.ShowCorrectImage();
        _correctSetCount++;
    }

    private void InputWrongKey()
    {
        _characterController.PlayInstructorEmote(EEmoteType.RedExclamation);
        _characterController.PlayStudentsEmote(EEmoteType.RedExclamation);
        _screenController.ShowIncorrectImage();
    }
}
