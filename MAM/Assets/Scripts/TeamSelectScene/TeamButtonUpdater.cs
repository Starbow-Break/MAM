using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

// ReSharper disable All
public class TeamButtonUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teamName;
    [SerializeField] private List<Image> _teamMemberImages;
    [SerializeField] private SimpleRadioButton _radioButton;

    private Team _team;

    public SimpleRadioButton RadioButton => _radioButton;
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
