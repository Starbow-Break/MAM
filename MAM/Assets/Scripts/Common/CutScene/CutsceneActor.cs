using UnityEngine;
using UnityEngine.U2D.Animation;

public class CutsceneActor : MonoBehaviour
{
    [SerializeField] private SpriteLibrary _spriteLibrary = null;
    [SerializeField] private SpriteResolver _spriteResolver = null;

    [SerializeField] private CharacterAnimator _animator = null;
    
    [SerializeField] private string _startCategory = "Idle_Front";
    [SerializeField] private string _startLabel = "Idle_Front_0";

    public CharacterAnimator Animator => _animator;

    public void SetActor(string studentID)
    {
        _spriteLibrary.spriteLibraryAsset = GameManager.StudentManager.GetStudentSpriteLibrary(studentID);
        _spriteResolver.SetCategoryAndLabel(_startCategory, _startLabel);
    }
}
