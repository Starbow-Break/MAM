using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchRaiseIntimacySetter : MonoBehaviour
{
    [SerializeField] private RaiseIntimacyUpdater _updater;
    [SerializeField] private Transform _parent;

    private List<RaiseIntimacyUpdater> _updaters = new();
    
    // 미리 생성
    public void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newUpdater = Instantiate(_updater, _parent);
            newUpdater.SetActive(false);
            _updaters.Add(newUpdater);
        }
    }

    public void SetStudents(List<Student> students)
    {
        int index = 0;
        foreach (var student in students)
        {
            if (index < _updaters.Count)
            {
                _updaters[index].SetStudent(student);
            }
            else
            {
                var newUpdater = Instantiate(_updater, _parent);
                newUpdater.SetStudent(student);
                _updaters.Add(newUpdater);
            }
            
            index++;
        }
    }

    public void ApplyLunch(List<Student> students, Restaurant restaurant)
    {
        SetStudents(students);
        StartCoroutine(ApplyLunchSequence(restaurant));
    }

    private IEnumerator ApplyLunchSequence(Restaurant restaurant)
    {
        var wait = new WaitForSeconds(1.0f);
        
        foreach (var updater in _updaters)
        {
            updater.SetActive(true);
            
            float targetIntimacy = StudentLevelHelper.GetRaisedIntimacy(updater.Student, restaurant);
            Student student = updater.Student;
            StartCoroutine(RaiseIntimacySequence(updater, student.Intimacy, targetIntimacy, 1.0f));
            yield return wait;
        }
    }

    private IEnumerator RaiseIntimacySequence(
        RaiseIntimacyUpdater updater,
        float beforeIntimacy,
        float targetIntimacy,
        float duration)
    {
        float difference = targetIntimacy - beforeIntimacy;
        
        float currentTime = 0.0f;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp(currentTime / duration, 0.0f, 1.0f);
            float value = RaiseCurve(normalizedTime);
            updater.SetIntimacy(beforeIntimacy + value * difference);
            yield return null;
        }
        
        yield return null;
    }
    
    // 수치 증가할 때 사용할 커브
    private float RaiseCurve(float t)
    {
        return Mathf.Sin(t / 2.0f * Mathf.PI);
    }
}
