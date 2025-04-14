using UnityEngine;
using UnityEngine.UI;

public class LectureSelectUpdater : MonoBehaviour
{
    [SerializeField] private SImpleRadioButton[] _lectureButtons = null;
    [SerializeField] private SImpleRadioButton[] _levelButtons = null;
    [SerializeField] private Button _startButton = null;
    
    public SImpleRadioButton[] LectureButtons => _lectureButtons;
    public SImpleRadioButton[] LevelButtons => _levelButtons;
    public Button StartButton => _startButton;
}
