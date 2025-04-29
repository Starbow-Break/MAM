using UnityEngine;
using System.Collections;

public class SpeechBubbleAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;

    private readonly int _hashIsTalking = Animator.StringToHash("IsTalking");
    private readonly int _hashIsEmote = Animator.StringToHash("IsEmote");
    private readonly int _hashExRed = Animator.StringToHash("ExRed");
    private readonly int _hashExBlue = Animator.StringToHash("ExBlue");
    
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
