using UnityEngine;
using UnityEngine.PlayerLoop;

public class LunchStudentSelectedInfoSetter : MonoBehaviour
{
    [SerializeField] private StudentSelectedInfoUpdater _updater;
    private void OnEnable()
    {
        LunchSceneManager.Controller.OnChangeStudent += () => UpdateText();
    }
    
    private void OnDisable()
    {
        LunchSceneManager.Controller.OnChangeStudent -= () => UpdateText();
    }

    public void Initialize()
    {
        UpdateText();
    }
    
    private void UpdateText()
    {
        int selectedStudentCount = LunchSceneManager.Controller.SelectedStudentCount;
        int maxSelectedStudent = LunchSceneManager.Controller.MaxSelectedStudent;
        _updater.SetText(selectedStudentCount, maxSelectedStudent);
    }
}
