using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable All
public class TeamSelectTeamButtonSetter : MonoBehaviour
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
            newUpdater.SetTeamName($"Team {newUpdater.TeamID}");
            newUpdater.AddOnClickEventListener(() =>
            {
                Debug.Log($"Selected Team : {newUpdater.TeamID}");
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
            var currentTeam = _controller.GetTeam(updater.TeamID);
            if (currentTeam != null)
            {
                updater.SetTeamMemberImage(0, currentTeam.Member1?.Icon);
                updater.SetTeamMemberImage(1, currentTeam.Member2?.Icon);
            }
        }
    }
}
