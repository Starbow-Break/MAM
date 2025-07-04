using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D.Animation;

public class CharacterClickDetector : MonoBehaviour
{
    public UnityAction OnCharacterClick { get; set; }
    private void OnMouseUpAsButton()
    {
        if (SelfStudySceneManager.StudentClickPopupSetter.IsPopupOpen)
        {
            return;
        }
        
        OnCharacterClick?.Invoke();
    }
}
