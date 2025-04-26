using UnityEngine;
using System.Collections;
using TMPro;

public class PresentSkillRaiseViewer
{
    private PresentSkillRaiseUpdater _updater = null;
    
    private readonly float _raiseTime = 1.5f;

    private float _startUnitySkillLevel = 0f;
    private float _startCSharpSkillLevel = 0f;
    private float _newUnitySkillLevel = 0f;
    private float _newCSharpSkillLevel = 0f;

    private Coroutine _unityRaiseCo = null;
    private Coroutine _csharpRaiseCo = null;
    public PresentSkillRaiseViewer(PresentSkillRaiseUpdater updater)
    {
        _updater = updater;
    }

    public void SetSkillLevel(float projectProgress, Student student)
    {
        _updater.SetInfo(student.Icon, student.Name);

        _startUnitySkillLevel = student.GetSkillLevel(ESkillType.Unity);
        _startCSharpSkillLevel = student.GetSkillLevel(ESkillType.CSharp);

        _updater.SetUnityLevel(Mathf.Floor(_startUnitySkillLevel));
        _updater.SetCSharpLevel(Mathf.Floor(_startCSharpSkillLevel));
        
        //스킬레벨 올리기
        float goal = GameManager.FlowManager.GetCurrentProjectGoal();
        StudentLevelHelper.ApplyProjectScore(student, projectProgress, goal, out _newUnitySkillLevel,
            out _newCSharpSkillLevel);
    }

    public void StartAllRaiseCo(MonoBehaviour setter)
    {
        _unityRaiseCo = setter.StartCoroutine(RaiseUnityCo());
        _csharpRaiseCo = setter.StartCoroutine(RaiseCSharpCo());
    }

    public void StopAllRaiseCo(MonoBehaviour setter)
    {
        if (_unityRaiseCo != null)
        {
            setter.StopCoroutine(_unityRaiseCo);
            _unityRaiseCo = null;
        }

        if (_csharpRaiseCo != null)
        {
            setter.StopCoroutine(_csharpRaiseCo);
            _csharpRaiseCo = null;
        }
    }

    public IEnumerator RaiseUnityCo()
    {
        _newUnitySkillLevel = Mathf.Floor(_newUnitySkillLevel);
        
        if (_newUnitySkillLevel - _startUnitySkillLevel < 1)
            yield break;

        float elapsedTime = 0f;

        while (elapsedTime < _raiseTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _raiseTime;
            float value = Mathf.Lerp(_startUnitySkillLevel, _newUnitySkillLevel, t);
            _updater.SetUnityLevel(value);
            yield return null;
        }

        _updater.SetUnityLevel(_newUnitySkillLevel);
        _unityRaiseCo = null;
    }

    public IEnumerator RaiseCSharpCo()
    {
        _newCSharpSkillLevel = Mathf.Floor(_newCSharpSkillLevel);
        
        if (_newCSharpSkillLevel - _startCSharpSkillLevel < 1)
            yield break;

        float elapsedTime = 0f;

        while (elapsedTime < _raiseTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / _raiseTime;
            float value = Mathf.Lerp(_startCSharpSkillLevel, _newCSharpSkillLevel, t);
            _updater.SetCSharpLevel(value);
            yield return null;
        }

        _updater.SetCSharpLevel(_newCSharpSkillLevel);
        _csharpRaiseCo = null;
    }

}
