using UnityEngine;
using UnityEngine.UI;

public class LectureResultUpdater : MonoBehaviour
{
    [SerializeField] private Transform _contentTransform = null;
    [SerializeField] private SkillRaiseUpdater _originalUpdater = null;
    [SerializeField] private Button _startButton = null;
    
    public Transform ContentTransform => _contentTransform;
    public SkillRaiseUpdater OriginalUpdater => _originalUpdater;
    public Button StartButton => _startButton;
}
