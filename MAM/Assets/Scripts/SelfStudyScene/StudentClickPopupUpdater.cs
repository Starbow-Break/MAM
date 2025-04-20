using UnityEngine;
using UnityEngine.UI;

public class StudentClickPopupUpdater : MonoBehaviour
{
    [SerializeField] private Button _backGroundButton = null;
    [SerializeField] private Button _carrotButton = null;
    [SerializeField] private Button _whipButton = null;
    [SerializeField] private Button _helpButton = null;
    [SerializeField] private StudentInfoUpdater _infoUpdater = null;
    
    public Button BackGroundButton => _backGroundButton;
    public Button CarrotButton => _carrotButton;
    public Button WhipButton => _whipButton;
    public Button HelpButton => _helpButton;
    public StudentInfoUpdater InfoUpdater => _infoUpdater;
}
