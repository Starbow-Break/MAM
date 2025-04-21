using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable All
public class TeamSelectTeamButtonSetter : MonoBehaviour
{
    [Header("Updater")]
    [SerializeField] private TeamButtonUpdater _updater;

    [Header("Instantiate")]
    [SerializeField] private Transform _parent;
    
    private List<TeamButtonUpdater> _updaters = new List<TeamButtonUpdater>();
    private RadioButtonGroup _teamGroup;
    
    private void OnEnable()
    {
        var controller = TeamSelectSceneManager.Controller;
        controller.OnChangeStudent += () => UpdateTeamMembers();
    }

    private void OnDisable()
    {
        var controller = TeamSelectSceneManager.Controller;
        controller.OnChangeStudent += () => UpdateTeamMembers();
    }

    public void Initialize(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            TeamButtonUpdater newUpdater = Instantiate(_updater, _parent);
            Team newTeam = new Team();
            newTeam.TeamNumber = i;
            
            newUpdater.SetTeam(newTeam);
            newUpdater.SetTeamName($"Team {newUpdater.Team.TeamNumber}");
            _updaters.Add(newUpdater);
        }

        List<SimpleRadioButton> buttons = new();
        for (int i = 0; i < count; i++)
        {
            SimpleRadioButton newButton = _updaters[i].RadioButton;
            buttons.Add(newButton);
        }
        _teamGroup = new RadioButtonGroup(buttons.ToArray());
        _teamGroup.OnValueChanged += (index) => UpdateController(index);
    }

    public void UpdateTeamMembers()
    {
        foreach (TeamButtonUpdater updater in _updaters)
        {
            var currentTeam = TeamSelectSceneManager.Controller.GetTeam(updater.Team.TeamNumber);
            if (currentTeam != null)
            {
                updater.SetTeamMemberImage(0, currentTeam.Member1?.Icon);
                updater.SetTeamMemberImage(1, currentTeam.Member2?.Icon);
            }
        }
    }

    private void UpdateController(int index)
    {
        var controller = TeamSelectSceneManager.Controller;
        controller.SelectTeam(index == -1 ? -1 : _updaters[index].Team.TeamNumber);
    }
}
