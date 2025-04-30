using UnityEngine;
using UnityEngine.U2D.Animation;

public class StudentCharacter : BaseCharacter
{
    [SerializeField] private CharacterClickDetector _detector = null;
    [SerializeField] private SpeechBubbleAnimator _speechBubbleAnimator = null;
    
    public SpeechBubbleAnimator SpeechBubbleAnimator => _speechBubbleAnimator;
    
    public void SetSpriteLibrary(SpriteLibraryAsset asset)
    {
        _spriteLibrary.spriteLibraryAsset = asset;
        _spriteResolver.SetCategoryAndLabel(_startCategory, _startLabel);
    }

    public void InitializeClickDetector()
    {
        _detector.gameObject.SetActive(true);
        _detector.OnCharacterClick += () => { SelfStudySceneManager.StudentClickPopupSetter.OpenPopup(ID); };
    }
}
