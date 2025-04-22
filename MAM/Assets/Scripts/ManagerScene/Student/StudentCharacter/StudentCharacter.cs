using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class StudentCharacter : MonoBehaviour
{
    [SerializeField] private SpriteLibrary _spriteLibrary = null;
    [SerializeField] private CharacterClickDetector _detector = null;
    [SerializeField] private SpriteResolver _spriteResolver = null;
    [SerializeField] private StudentCharacterAnimator _animator = null;
    
    private readonly string _startCategory = "Idle_Front";
    private readonly string _startLabel = "Idle_Front_0";
    
    public StudentCharacterAnimator Animator => _animator;
    public string ID {get; set;}
    
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
