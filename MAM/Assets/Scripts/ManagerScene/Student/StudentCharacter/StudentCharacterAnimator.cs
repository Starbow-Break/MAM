using UnityEngine;
using UnityEngine.U2D.Animation;

public class StudentCharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;

    private readonly int _hashX = Animator.StringToHash("X");
    private readonly int _hashY = Animator.StringToHash("Y");

    public void TurnFront()
    {
        _animator.SetFloat(_hashX, 0);
        _animator.SetFloat(_hashY, -1);
    }

    public void TurnBack()
    {
        _animator.SetFloat(_hashX, 0);
        _animator.SetFloat(_hashY, 1);
    }

    public void TurnLeft()
    {
        _animator.SetFloat(_hashX, -1);
        _animator.SetFloat(_hashY, 0);
    }
    
    public void TurnRight()
    {
        _animator.SetFloat(_hashX, 1);
        _animator.SetFloat(_hashY, 0);
    }
}
