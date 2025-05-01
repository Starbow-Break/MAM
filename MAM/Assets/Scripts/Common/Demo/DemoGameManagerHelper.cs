using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DemoGameManagerHelper : MonoBehaviour
{
    private void Start()
    {
        SetEventSystem();
        SetAudioListener();
    }

    //이벤트시스템 생성
    private void SetEventSystem()
    {       
        if (FindFirstObjectByType<EventSystem>() == null)
        {
            var obj = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }

    private void SetAudioListener()
    {
        if (FindFirstObjectByType<AudioListener>() == null)
        {
            var audioObj = new GameObject("AudioListener");
            audioObj.AddComponent<AudioListener>();
        }
    }

    public void SetDemoTeam()
    {
        List<Student> students = GameManager.StudentManager.GetStudents();
        List<Team> teams = new List<Team>();
        int teamNum = 1;
        for (int i = 0; i < students.Count; i+=2)
        {
            Team team = new Team();
            team.Member1 = students[i];
            team.Member2 = students[i + 1];
            team.TeamNumber = teamNum;
            teamNum++;
            
            team.ProjectProgress = Random.Range(0, 100);
            teams.Add(team);
        }
        
        GameManager.TeamManager.SetTeams(teams);
    }
}
