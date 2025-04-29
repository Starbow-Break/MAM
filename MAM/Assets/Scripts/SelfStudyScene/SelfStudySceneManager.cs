using UnityEngine;
using UnityEngine.UI;

public class SelfStudySceneManager : ASceneManager<SelfStudySceneManager>
{
    [SerializeField] private StudentClickPopupSetter _studentClickPopupSetter = null;
    [SerializeField] private SelfStudySceneCharacterSetter _characterSetter = null;
    [SerializeField] private Button _toHomeButton = null;

    public int InteractionCount { get; private set; } = 3;
    public static StudentClickPopupSetter StudentClickPopupSetter => Instance._studentClickPopupSetter;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _studentClickPopupSetter.Initialize();
        _characterSetter.Initialize();
        _toHomeButton.onClick.AddListener(GameManager.FlowManager.ToNextScene);
    }

    public void UseInteractionCount()
    {
        InteractionCount--;
        
        if(InteractionCount <= 0)
            GameManager.FlowManager.ToNextScene();
    }

}
