using UnityEngine;
using System.Collections;

public class SkillRaiseViewer
{
    private SkillRaiseUpdater _updater = null;
    
    private Student _student = null;

    private readonly float _raiseTime = 1.5f;
    private float _startSkillLevel = 0f;
    private float _newSkillLevel = 0f;

    public SkillRaiseViewer(SkillRaiseUpdater updater, string studentId)
    {
        _updater = updater;
        
        _student = GameManager.StudentManager.GetStudent(studentId);
        _updater.SetInfo(_student.Icon, _student.Name);
    }

    public void SetSkillTypeLevel(ESkillType skillType, int score, int miniGameDifficulty)
    {
        _updater.gameObject.SetActive(true);
        _updater.SetSkillType(skillType);
        _startSkillLevel = _student.GetSkillLevel(skillType);

        _updater.SetLevel(Mathf.Floor(_startSkillLevel));
        
        //스킬레벨 올리기
        _newSkillLevel = StudentLevelHelper.ApplyMiniGameScore(_student,skillType, score, miniGameDifficulty);
        _newSkillLevel = Mathf.Floor(_newSkillLevel);
    }
    
    public IEnumerator RaiseCo()
    {
        if(_newSkillLevel - _startSkillLevel < 1)
            yield break;
        
        float elapsedTime = 0f;
        
        while (elapsedTime < _raiseTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _raiseTime;
            float value = Mathf.Lerp(_startSkillLevel, _newSkillLevel, t);
            _updater.SetLevel(value);
            yield return null;
        }
        
        _updater.SetLevel(_newSkillLevel);
        yield return null;
    }
}
