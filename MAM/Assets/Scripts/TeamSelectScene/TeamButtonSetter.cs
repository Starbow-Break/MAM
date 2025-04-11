using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All
public class TeamButtonSetter : MonoBehaviour
{
    [SerializeField] private TeamSelectSceneController _controller;
    [SerializeField] private TeamButtonUpdater _updater;
    [SerializeField] private Transform _parent;
    
    private List<TeamButtonUpdater> _updaters = new List<TeamButtonUpdater>();

    private void OnEnable()
    {
        _controller.OnChangeTeam += () => UpdateTeamButtons();
        _controller.OnChangeStudent += () => UpdateTeamButtons();
    }

    private void OnDisable()
    {
        _controller.OnChangeTeam -= () => UpdateTeamButtons();
        _controller.OnChangeStudent -= () => UpdateTeamButtons();
    }

    public void Initialize(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            TeamButtonUpdater newUpdater = Instantiate(_updater, _parent);
            TeamButton button = newUpdater.GetComponent<TeamButton>();
            newUpdater.AddOnClickEventListener(() =>
            {
                _controller.SelectTeam(button.TeamId);
            });
            _updaters.Add(newUpdater);
        }
    }

    public void UpdateTeamButtons()
    {
        foreach (TeamButtonUpdater updater in _updaters)
        {
            TeamButton button = updater.GetComponent<TeamButton>();
            updater.SetHighlight(_controller.SelectedTeamId == button.TeamId);
        }
    }
}
