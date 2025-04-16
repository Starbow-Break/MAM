using UnityEngine;
using UnityEngine.PlayerLoop;

public class LunchStudentSelectedInfoSetter : MonoBehaviour
{
    [SerializeField] private LunchSceneController _controller;
    [SerializeField] private StudentSelectedInfoUpdater _updater;
    private void OnEnable()
    {
        _controller.OnChangeStudent += () => UpdateText();
    }
    
    private void OnDisable()
    {
        _controller.OnChangeStudent -= () => UpdateText();
    }

    public void Initialize()
    {
        UpdateText();
    }
    
    private void UpdateText()
    {
        _updater.SetText(_controller.SelectedStudentCount, _controller.MaxSelectedStudent);
    }
}
