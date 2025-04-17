using TMPro;
using UnityEngine;

public class StudentInfoFavRestaurantUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _favRestaurantText;
    private static string _unrevealedDisplayString = "???";
    
    public void SetStudentFavRestaurant(Student student)
    {
        bool isReveal = StudentInfoRevealChecker.CheckFavRestaurantReveal(student);
        if (isReveal)
        {
            _favRestaurantText.text = student.MBTI;
        }
        else
        {
            _favRestaurantText.text = _unrevealedDisplayString;
        }
    }
}
