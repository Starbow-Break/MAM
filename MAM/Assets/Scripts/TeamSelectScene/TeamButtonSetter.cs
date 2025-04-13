using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable All
public class TeamButtonSetter : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private TeamSelectSceneController _controller;

    [Header("Updater")]
    [SerializeField] private TeamButtonUpdater _updater;

    [Header("Instantiate")]
    [SerializeField] private Transform _parent;
    
    private List<TeamButtonUpdater> _updaters = new List<TeamButtonUpdater>();

    private void OnEnable()
    {
        _controller.OnChangeTeam += () => UpdateTeamSelected();
        _controller.OnChangeStudent += () => UpdateTeamMembers();
    }

    private void OnDisable()
    {
        _controller.OnChangeTeam -= () => UpdateTeamSelected();
        _controller.OnChangeStudent += () => UpdateTeamMembers();
    }

    public void Initialize(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            TeamButtonUpdater newUpdater = Instantiate(_updater, _parent);
            newUpdater.TeamID = i;
            newUpdater.AddOnClickEventListener(() =>
            {
                _controller.SelectTeam(newUpdater.TeamID);
            });
            _updaters.Add(newUpdater);
        }
    }

    public void UpdateTeamSelected()
    {
        foreach (TeamButtonUpdater updater in _updaters)
        {
            updater.SetSelected(_controller.SelectedTeamId == updater.TeamID);
        }
    }

    public void UpdateTeamMembers()
    {
        foreach (TeamButtonUpdater updater in _updaters)
        {
            var memberIDs = _controller.GetTeamMembers(updater.TeamID);

            if (memberIDs != null)
            {
                for (int i = 0; i < memberIDs.Length; i++) {
                    Student student = GameManager.StudentManager.GetStudent(memberIDs[i]);
                    updater.SetTeamMemberImage(i, student?.Icon);
                }
            }
        }
    }
}
