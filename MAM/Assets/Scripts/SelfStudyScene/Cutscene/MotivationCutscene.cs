using UnityEngine;

public class MotivationCutscene : MonoBehaviour
{
    [SerializeField] private CutsceneActor _student = null;

    private void OnEnable()
    {
        Student student = SelfStudySceneManager.StudentClickPopupSetter.SelectedStudent;
        
        if (student == null)
            return;
        
        _student.SetActor(student.ID);
    }
}
