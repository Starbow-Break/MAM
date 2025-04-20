using UnityEngine;
using UnityEngine.UI;

public class LectureSelectUpdater : MonoBehaviour
{
    [SerializeField] private SimpleRadioButton[] _lectureButtons = null;
    [SerializeField] private SimpleRadioButton[] _levelButtons = null;
    [SerializeField] private Button _startButton = null;
    
    public SimpleRadioButton[] LectureButtons => _lectureButtons;
    public SimpleRadioButton[] LevelButtons => _levelButtons;
    public Button StartButton => _startButton;
}
