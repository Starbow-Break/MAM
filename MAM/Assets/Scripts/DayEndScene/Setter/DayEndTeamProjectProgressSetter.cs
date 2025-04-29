
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEndTeamProjectProgressSetter : MonoBehaviour
{
    [SerializeField] private TeamProjectProgressUpdater _updater;
    [SerializeField] private Transform _parent;
    [SerializeField, Min(0.1f)] private float raiseDuration = 1.0f;
    [SerializeField, Min(0.1f)] private float itemActiveInterval = 0.4f;
    
    List<TeamProjectProgressUpdater> _updaters = new List<TeamProjectProgressUpdater>();
    
    // 본격적으로 보여주기 전에 미리 초기화
    public void Initialize()
    {
        List<Team> teams = GameManager.TeamManager.GetTeams();
        foreach (Team team in teams)
        {
            var newUpdater = Instantiate(_updater, _parent);
            newUpdater.SetTeam(team);
            newUpdater.SetProgress(team.ProjectProgress);
            newUpdater.SetActive(false);
            
            _updaters.Add(newUpdater);
        }
    }
    
    // 하루 종료 결과를 반영
    public void ApplyDayEnd()
    {
        StartCoroutine(ApplyDayEndSequence());
    }
    
    // 하루 종료 결과를 반영하는 코루틴
    private IEnumerator ApplyDayEndSequence()
    {
        var wait = new WaitForSeconds(itemActiveInterval);
        
        foreach (var updater in _updaters)
        {
            updater.SetActive(true);
            
            Team team = updater.Team;
            float beforeProgress = team.ProjectProgress;
            float targetProgress = TeamProjectProgressHelper.ApplyDayEnd(team);
            
            StartCoroutine(RaiseProgressSequence(updater, beforeProgress, targetProgress, raiseDuration));
            yield return wait;
        }
    }
    
    // 진행률을 점진적으로 증가시키기 위한 코루틴
    private IEnumerator RaiseProgressSequence(
        TeamProjectProgressUpdater updater,
        float before, 
        float target, 
        float duration)
    {
        float currentTime = 0.0f;   // 시간
        float difference = target - before;   // 차이
        
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float normalizetime = Mathf.Clamp(currentTime / duration, 0f, 1f);
            float value = RaiseCurve(normalizetime);
            
            updater.SetProgress(before + difference * value);
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
