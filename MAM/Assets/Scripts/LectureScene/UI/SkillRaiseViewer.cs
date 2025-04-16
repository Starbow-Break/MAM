using Unity.VisualScripting;
using UnityEngine;

public class SkillRaiseViewer
{
    private SkillRaiseUpdater _updater = null;

    public SkillRaiseViewer(SkillRaiseUpdater updater, string studentId, string statType)
    {
        _updater = updater;
        
        Student student = GameManager.StudentManager.GetStudent(studentId);
        //_updater.SetInfo(student.Icon, student.Name,statType,stu );
    }
    
    
}
