using TMPro;
using UnityEngine;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;

public class TeamRankButtonUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _teamRank;
    [SerializeField] private List<Image> _teamMemberImages;
    [SerializeField] private List<TextMeshProUGUI> _teamMemeberNames;
    [SerializeField] private SimpleRadioButton _radioButton;
    [SerializeField] private TextMeshProUGUI _gradeText;

    private Team _team;

    public SimpleRadioButton RadioButton => _radioButton;
    public Team Team
    {
        get { return _team; }
    }

    public void SetRank(int rank)
    {
        _teamRank.text = rank.ToString();
    }
    
    public void SetTeam(Team team)
    {
        _team = team;
        SetTeamMemberImage(0, team.Member1?.Icon);
        SetTeamMemberImage(1, team.Member2?.Icon);
        SetTeamMemberName(0, team.Member1?.Name);
        SetTeamMemberName(1, team.Member2?.Name);
    }
    
    private void SetTeamMemberImage(int imageIndex, Sprite sprite)
    {
        _teamMemberImages[imageIndex].sprite = sprite;
    }

    private void SetTeamMemberName(int imageIndex, string memberName)
    {
        _teamMemeberNames[imageIndex].text = memberName;

    }

    public void SetGrade(string grade)
    {
        _gradeText.text = grade;
    }
}
