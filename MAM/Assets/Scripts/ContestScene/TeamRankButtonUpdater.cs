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

    private ContestTeam _team;

    public SimpleRadioButton RadioButton => _radioButton;
    public ContestTeam Team
    {
        get { return _team; }
    }

    public void SetRank(int rank)
    {
        _teamRank.text = rank.ToString();
    }
    
    public void SetTeam(ContestTeam team)
    {
        _team = team;
        SetTeamMemberImage(0, team.Members[0].CharacterIcon);
        SetTeamMemberImage(1, team.Members[1].CharacterIcon);
        SetTeamMemberName(0, team.Members[0].CharacterName);
        SetTeamMemberName(1, team.Members[1].CharacterName);
        
        SetGrade(team.ProjectScore);
    }
    
    private void SetTeamMemberImage(int imageIndex, Sprite sprite)
    {
        _teamMemberImages[imageIndex].sprite = sprite;
    }

    private void SetTeamMemberName(int imageIndex, string memberName)
    {
        _teamMemeberNames[imageIndex].text = memberName;
    }

    private void SetGrade(float score)
    {
        _gradeText.text = Mathf.Floor(score).ToString();
    }
}
