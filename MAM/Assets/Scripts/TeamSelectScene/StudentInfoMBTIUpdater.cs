using TMPro;
using UnityEngine;

public class StudentInfoMBTIUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _mbtiText;
    private static string _unrevealedDisplayString = "???";

    public void SetStudentMBTI(Student student)
    {
        bool isReveal = StudentInfoRevealChecker.CheckMBTIReveal(student);
        if (isReveal)
        {
            _mbtiText.text = student.MBTI;
        }
        else
        {
            _mbtiText.text = _unrevealedDisplayString;
        }
    }
}
