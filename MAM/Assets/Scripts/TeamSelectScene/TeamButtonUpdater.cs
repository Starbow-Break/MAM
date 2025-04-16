using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// ReSharper disable All
public class TeamButtonUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teamName;
    [SerializeField] private List<Image> _teamMemberImages;

    private Team _team;

    public Team Team
    {
        get { return _team; }
    }

    public void SetTeam(Team team)
    {
        _team = team;
        SetTeamMemberImage(0, team.Member1?.Icon);
        SetTeamMemberImage(1, team.Member2?.Icon);
    }

    public void SetTeamName(string teamName)
    {
        _teamName.text = teamName;
    }

    public void SetTeamMemberImage(int imageIndex, Sprite sprite)
    {
        _teamMemberImages[imageIndex].sprite = sprite;
    }
}
