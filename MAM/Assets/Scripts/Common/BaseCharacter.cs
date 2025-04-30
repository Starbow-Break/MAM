using UnityEngine;
using UnityEngine.U2D.Animation;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected SpriteLibrary _spriteLibrary = null;
    [SerializeField] protected SpriteResolver _spriteResolver = null;
    [SerializeField] protected CharacterAnimator _animator = null;
    
    [SerializeField] protected string _startCategory = "Idle_Front";
    [SerializeField] protected string _startLabel = "Idle_Front_0";

    public CharacterAnimator Animator => _animator;
    public string ID {get; set; }
}
