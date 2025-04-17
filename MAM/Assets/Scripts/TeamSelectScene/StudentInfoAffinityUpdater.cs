using UnityEngine;
using UnityEngine.UI;

public class StudentInfoAffinityUpdater : MonoBehaviour
{
    [SerializeField] private GameObject _hiddenUI;
    [SerializeField] private GameObject _affinityValueUI;
    [SerializeField] private Image _affinityImage;
    
    [Header("Sprites")]
    [SerializeField] private Sprite carrot;
    [SerializeField] private Sprite whip;

    public void SetStudentAffinity(Student student)
    {
        bool isReveal = StudentInfoRevealChecker.CheckAffinityTypeReveal(student);
        if (isReveal)
        {
            _hiddenUI.SetActive(false);
            _affinityValueUI.SetActive(true);

            Sprite affinitySprite = student.AffinityType switch
            {
                EAffinityType.Carrot => carrot,
                EAffinityType.Whip => whip
            };
            
            _affinityImage.sprite = affinitySprite;
        }
        else
        {
            _hiddenUI.SetActive(true);
            _affinityValueUI.SetActive(false);
        }
    }
}
