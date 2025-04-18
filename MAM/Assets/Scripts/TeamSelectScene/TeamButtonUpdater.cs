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

    public Team Team { get; private set; }

    public void SetTeam(Team team)
    {
        Team = team;
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
