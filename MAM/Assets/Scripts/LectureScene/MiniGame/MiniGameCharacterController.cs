using System;
using UnityEngine;

public enum EEmoteType
{
    None = 0,
    BlueExclamation = 1,
    RedExclamation = 2
}

public class MiniGameCharacterController : MonoBehaviour
{
    [SerializeField] private StudentCharacter _instructor = null;
    [SerializeField] private StudentCharacter[] _students = null;

    public void Start()
    {
        foreach (StudentCharacter student in _students)
        {
            student.Animator.TurnBack();
        }
    }

    public void SetInstructorTalking(bool isTalking)
    {
        _instructor.Animator.SetIsTalking(isTalking);
    }

    private void PlayEmote(StudentCharacter character, EEmoteType emoteType, float duration)
    {
        switch (emoteType)
        {
            case EEmoteType.BlueExclamation:
                character.Animator.PlayExclamationBlue(duration);
                break;
            case EEmoteType.RedExclamation:
                character.Animator.PlayExclamationRed(duration);
                break;
        }
    }

    public void PlayStudentsEmote(EEmoteType emoteType, float duration = 0.3f)
    {
        for (int i = 0; i < _students.Length; i++)
        {
            PlayEmote(_students[i], emoteType, duration);
        }
    }

    public void PlayInstructorEmote(EEmoteType emoteType, float duration = 0.3f)
    {
        PlayEmote(_instructor, emoteType, duration);
    }
}
