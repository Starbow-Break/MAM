using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StudentButtonAnimator : MonoBehaviour
{
    private Animator _animator = null;

    private readonly int _disabledTrigger = Animator.StringToHash("Disabled");
    private readonly int _normalTrigger = Animator.StringToHash("Normal");
    private readonly int _selectedTrigger = Animator.StringToHash("Selected");

    public void Awake()
    {
        _animator = GetComponent<Animator>();    
    }
    
    public void PlayDisabledAnimation() 
        => _animator.SetTrigger(_disabledTrigger);

    public void PlayNormalAnimation() 
        => _animator.SetTrigger(_normalTrigger);

    public void PlaySelectedAnimation() 
        => _animator.SetTrigger(_selectedTrigger);
}
