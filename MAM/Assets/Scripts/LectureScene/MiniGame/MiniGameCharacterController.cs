using UnityEngine;

public enum EEmoteType
{
    None = 0,
    BlueExclamation = 1,
    RedExclamation = 2
}

public class MiniGameCharacterController : MonoBehaviour
{
    [SerializeField] private StudentCharacter _instructor;
    [SerializeField] private StudentCharacter[] _students;

    public void Start()
    {
        foreach (var student in _students) student.Animator.TurnBack();
    }

    public void SetInstructorTalking(bool isTalking)
    {
        _instructor.SpeechBubbleAnimator.SetIsTalking(isTalking);
    }

    private void PlayEmote(StudentCharacter character, EEmoteType emoteType, float duration)
    {
        switch (emoteType)
        {
            case EEmoteType.BlueExclamation:
                character.SpeechBubbleAnimator.PlayExclamationBlue(duration);
                break;
            case EEmoteType.RedExclamation:
                character.SpeechBubbleAnimator.PlayExclamationRed(duration);
                break;
        }
    }

    public void PlayStudentsEmote(EEmoteType emoteType, float duration = 0.3f)
    {
        for (var i = 0; i < _students.Length; i++) PlayEmote(_students[i], emoteType, duration);
    }

    public void PlayInstructorEmote(EEmoteType emoteType, float duration = 0.3f)
    {
        PlayEmote(_instructor, emoteType, duration);
    }
}