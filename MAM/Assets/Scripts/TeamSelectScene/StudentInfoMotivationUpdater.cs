using UnityEngine;

public class StudentInfoMotivationUpdater : MonoBehaviour
{
    private readonly int _motivationIntParam = Animator.StringToHash("Motivation");
    private readonly float[] _motivationLevelBound = new float[5] { 0.0f, 1.0f, 2.0f, 3.0f, 4.0f };
    
    [SerializeField] private GameObject _hiddenUI;
    [SerializeField] private GameObject _motivationValueUI;
    [SerializeField] private Animator _motivationAnimator;
    
    public void SetStudentMotivation(Student student)
    {
        bool isReveal = StudentInfoRevealChecker.CheckMotivationReveal(student);
        if (isReveal)
        {
            _hiddenUI.SetActive(false);
            _motivationValueUI.SetActive(true);

            int motivationLevel = GetMotivationLevel(student.Motivation);
            _motivationAnimator.SetInteger(_motivationIntParam, motivationLevel);
        }
        else
        {
            _hiddenUI.SetActive(true);
            _motivationValueUI.SetActive(false);
        }
    }

    private int GetMotivationLevel(float motivation)
    {
        int result = 0;
        for (; result < 5; result++)
        {
            if (motivation < _motivationLevelBound[result])
            {
                break;
            }
        }

        return result;
    }
}
