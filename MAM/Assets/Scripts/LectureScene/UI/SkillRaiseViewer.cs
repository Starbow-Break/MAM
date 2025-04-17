using Unity.VisualScripting;
using UnityEngine;

public class SkillRaiseViewer
{
    private SkillRaiseUpdater _updater = null;
    //private float _raiseSpeed = 1.0f;
    private Student _student = null;

    public SkillRaiseViewer(SkillRaiseUpdater updater, string studentId)
    {
        _updater = updater;
        
        _student = GameManager.StudentManager.GetStudent(studentId);
        _updater.SetInfo(_student.Icon, _student.Name);
    }

    public void SetSkillTypeLevel(ESkillType skillType)
    {
        _updater.SetSkillType(skillType);
        _updater.SetLevel(_student.GetSkillLevel(skillType));
    }
    
    public void StartRaising()
    {
        
    }
    
}
