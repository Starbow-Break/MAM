using TMPro;
using UnityEngine;

public class TeamGradeButtonUpdater : TeamButtonUpdater
{
    [SerializeField] private TextMeshProUGUI _gradeText;

    public void SetGrade(string grade)
    {
        _gradeText.text = grade;
    }
}
