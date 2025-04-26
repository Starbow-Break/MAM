using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;

    private readonly int _hashX = Animator.StringToHash("X");
    private readonly int _hashY = Animator.StringToHash("Y");
    
    private readonly int _hashIsTalking = Animator.StringToHash("IsTalking");
    private readonly int _hashIsEmote = Animator.StringToHash("IsEmote");
    private readonly int _hashExRed = Animator.StringToHash("ExRed");
    private readonly int _hashExBlue = Animator.StringToHash("ExBlue");

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

    public void SetIsTalking(bool isTalking)
    {
        _animator.SetBool(_hashIsTalking, isTalking);
    }

    public void PlayExclamationRed(float duration = 0.3f)
    {
        StopAllCoroutines();
        StartCoroutine(PlayExclamation(_hashExRed,duration));
    }

    public void PlayExclamationBlue(float duration = 0.3f)
    {
        StopAllCoroutines();
        StartCoroutine(PlayExclamation(_hashExBlue,duration));
    }

    private IEnumerator PlayExclamation(int hash, float duration)
    {
        _animator.SetTrigger(hash);
        _animator.SetBool(_hashIsEmote, true);
        
        yield return new WaitForSeconds(duration);
        
        _animator.SetBool(_hashIsEmote, false);
    }
}
