using TMPro;
using UnityEngine;

public class CommonHUDUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _projectText = null;
    [SerializeField] private TextMeshProUGUI _dayText = null;

    public void SetProjectText(int projectNumber)
    {
        _projectText.text = $"Project {projectNumber}";
    }

    public void SetDayText(int day)
    {
        _dayText.text = $"Day {day}";
    }
}
